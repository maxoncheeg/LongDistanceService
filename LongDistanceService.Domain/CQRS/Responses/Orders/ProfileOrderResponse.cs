using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Order;
using LongDistanceService.Domain.Models.Abstract.Personals;
using LongDistanceService.Domain.Models.Abstract.Vehicles;

namespace LongDistanceService.Domain.CQRS.Responses.Orders;

public class ProfileOrderResponse : IProfileOrder
{
    public int Id { get; set; }
    public required IVehicleInfo Vehicle { get; set; }
    public ClientTypes ReceiverType { get; set; }
    public ClientTypes SenderType { get; set; }
    public int ReceiverId => IndividualReceiver?.Id ?? LegalReceiver?.Id ?? -1;
    public int SenderId => IndividualSender?.Id ?? LegalSender?.Id ?? -1;
    public string ReceiverName => IndividualReceiver?.Fullname ?? LegalReceiver?.CompanyName ?? string.Empty;
    public string SenderName => IndividualSender?.Fullname ?? LegalSender?.CompanyName ?? string.Empty;
    public string SendAddress { get; set; } = string.Empty;
    public string ReceiveAddress { get; set; } = string.Empty;
    public OrderState State { get; set; }
    public decimal RouteLength { get; set; }
    public DateTime? LoadingDate { get; set; }
    public IIndividualInfo? IndividualSender { get; set; }
    public IIndividualInfo? IndividualReceiver { get; set; }
    public ILegalInfo? LegalSender { get; set; }
    public ILegalInfo? LegalReceiver { get; set; }
}