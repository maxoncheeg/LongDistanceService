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
        var role = await context.Users.Include(p => p.Role)
            .SingleOrDefaultAsync(r => r.Id == request.UserId, cancellationToken);
        if (role == null) return Array.Empty<MenuItemResponse>();

        var menuTabs = await context.MenuTabRights
            .Where(r => r.RoleId == role.RoleId)
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

        menuTabs.Sort((a, b) => a.Order < b.Order ? -1 : 1);
        menuTabs.Sort((l, r) => l.ParentId < r.ParentId ? -1 : 1);

        while (menuTabs.Any(m => m.ParentId != 0))
        {
            List<MenuItemResponse> list = new();
            int currentParentId = menuTabs.Last().ParentId;

            for (int i = menuTabs.Count - 1; i >= 0; i--)
            {
                if (menuTabs[i].Id == 11 || menuTabs[i].ParentId == 11)
                    Console.WriteLine("text");
                if (menuTabs[i].Id == currentParentId)
                {
                    //currentParentId = menuTabs[i].ParentId;
                    IList<MenuItemResponse>? children = menuTabs[i].Children?.Select(r => new MenuItemResponse()
                    {
                        Id = r.Id, ParentId = menuTabs[i].Id, Children = r.Children, Dll = r.Dll, Name = r.Name,
                        Route = r.Route, Order = r.Order
                    }).ToList();

                    if (children != null)
                        list = [..list.Concat(children)];

                    list.Sort((l, r) => l.Order < r.Order ? -1 : 1);
                    menuTabs[i].Children = [..list];
                    list.Clear();


                    break;
                }
                else if (menuTabs[i].ParentId != currentParentId)
                    continue;

                if (currentParentId != 0)
                {
                    list.Add(menuTabs[i]);
                    menuTabs.RemoveAt(i);
                }
            }
        }


        return menuTabs;
    }

    // public List<MenuItemResponse> SortByOrder(List<MenuItemResponse> menus)
    // {
    //     menus.Sort((l, r) => l.Order < r.Order ? -1 : 1);
    //
    //     foreach (var menu in menus)
    //     {
    //         if (menu.Children != null)
    //             menu.Children = SortByOrder([..menu.Children]);
    //     }
    // }
}