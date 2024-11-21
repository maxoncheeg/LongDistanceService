using LongDistanceService.Data.Contexts;
using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Menus;
using LongDistanceService.Domain.CQRS.Responses.Menus;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Menus;

public class GetMenuHandler(IApplicationDbContext context) : IRequestHandler<GetMenuRequest, IList<MenuItemResponse>>
{
    public async Task<IList<MenuItemResponse>> Handle(GetMenuRequest request, CancellationToken cancellationToken)
    {
        var menuTabs = await context.MenuTabRights
            .Where(r => r.UserId == request.UserId)
            .Include(p => p.MenuTab)
            .Select(r => new MenuItemResponse()
            {
                Id = r.MenuTab.Id,
                ParentId = r.MenuTab.ParentId,
                Dll = r.MenuTab.DllName,
                Name = r.MenuTab.Name,
                Route = r.MenuTab.FunctionName,
                Order = r.MenuTab.Order,
            })
            .ToListAsync(cancellationToken);

        menuTabs.Sort((l, r) => l.ParentId < r.ParentId ? -1 : 1);

        while (menuTabs.Any(m => m.ParentId != 0))
        {
            List<MenuItemResponse> list = new();
            int currentParentId = menuTabs.Last().ParentId;
            
            for (int i = menuTabs.Count - 1; i >= 0; i--)
            {
                if (menuTabs[i].Id == currentParentId)
                {
                    currentParentId = menuTabs[i].ParentId;
                    list.Sort((l, r) => l.Order < r.Order ? -1 : 1);
                    menuTabs[i].Children = [..list];
                    list.Clear();
                    
                    if (currentParentId == 0) break;
                }
                else if (menuTabs[i].ParentId != currentParentId)
                    continue;

                if(currentParentId != 0)
                {
                    list.Add(menuTabs[i]);
                    menuTabs.RemoveAt(i);
                }
            }
        }
        
        return menuTabs;
    }
}