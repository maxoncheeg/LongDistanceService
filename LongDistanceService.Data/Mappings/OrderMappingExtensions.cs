using LongDistanceService.Data.Entities;
using LongDistanceService.Domain.CQRS.Responses.Orders;
using LongDistanceService.Domain.CQRS.Responses.Vehicles;
using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Data.Mappings;

public static class OrderMappingExtensions
{
    public static IQueryable<SlimOrderResponse> ToSlimOrderResponse(this IQueryable<Order> @this)
    {
        var query = @this.Select(order => new SlimOrderResponse
        {
            Id = order.Id,
            IndividualReceiver = order.IndividualReceiver.ToSlimIndividualResponse() ?? null,
            IndividualSender = order.IndividualSender.ToSlimIndividualResponse() ?? null,
            LegalReceiver = order.LegalReceiver.ToSlimLegalResponse() ?? null,
            LegalSender = order.LegalSender.ToSlimLegalResponse() ?? null,
            
            ReceiverType = order.IndividualReceiverId != null ? ClientTypes.Individual : ClientTypes.Legal,
            SenderType = order.IndividualSenderId != null ? ClientTypes.Individual : ClientTypes.Legal,
            
            SendAddress = order.SendCity.Name + ", " + order.SendStreet.Name + " " + order.SendHouseNumber,
            ReceiveAddress = order.ReceiveCity.Name + ", " + order.ReceiveStreet.Name + " " + order.ReceiveHouseNumber,
            RouteLength = order.RouteLength,
            LoadingDate = order.LoadingDate,
            State = order.State,
            Vehicle = new VehicleInfoResponse(
                order.Vehicle.Id, 
                $"{order.Vehicle.Model.Brand.Name}, {order.Vehicle.Model.Name}", 
                order.Vehicle.LicensePlate,
                order.Vehicle.ImagePath),
        });


        return query;
    }
}