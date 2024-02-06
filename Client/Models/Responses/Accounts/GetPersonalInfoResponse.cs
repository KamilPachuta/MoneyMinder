using Client.Models.ReadModels;
using MoneyMinderClient.Models.Responses;

namespace Client.Models.Responses.Accounts;

public class GetPersonalInfoResponse: IResponse
{
    public PersonalInfoModel PersonalInfo { get; set; }

    public GetPersonalInfoResponse()
    {
        
    }
    
    public GetPersonalInfoResponse(PersonalInfoModel personalInfo)
    {
        PersonalInfo = personalInfo;
    }

}