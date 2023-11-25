using DinnerMetting.Application.Authentication.Common;
using DinnerMetting.Contracts.Authentication;
using Mapster;

namespace DinnerMetting.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // all mapping works out of the box
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.Token, src => src.Token);
    }
}
