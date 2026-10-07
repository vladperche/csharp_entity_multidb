
using Entity.MultiDB.Entities.Resources;

namespace Entity.MultiDB.Entities.Models.Response;

public class HealthCheckResponseModel : BaseResponseModel
{
    public HealthCheckResponseModel()
    {
        Status = (int)System.Net.HttpStatusCode.OK;
        Message = Messages.HEALTH_CHECK_OK;
    }

    public string Environment { get; set; } = System.Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Unknown";
}
