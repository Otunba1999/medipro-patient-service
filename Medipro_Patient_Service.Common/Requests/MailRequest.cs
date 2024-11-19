namespace Medipro_Patient_Service.Common.Requests;

public class MailRequest
{
    public string Recipient { get; set; } = string.Empty;
    public string Subject { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    
}