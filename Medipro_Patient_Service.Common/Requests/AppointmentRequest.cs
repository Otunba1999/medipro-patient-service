namespace Medipro_Patient_Service.Common.Requests;

public class AppointmentRequest
{
    public string Subject { get; set; } = string.Empty;
    public string PatientId { get; set; } = string.Empty;
    public string ProviderId { get; set; } = string.Empty;
    public string Note { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public bool IsAllDay { get; set; }
}