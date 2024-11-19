namespace medipro_patient_service.Application.DTO;

public record UserDetail(
    string UserId,
    string Email,
    string Name,
    RealmAccess Access);

public record Role(List<string> Roles);

public record RealmAccess(List<string> Roles);