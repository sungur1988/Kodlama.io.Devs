using Application.Features.Auths.Rules;
using Application.Features.LanguageTechs.Rules;
using Application.Features.OperationClaims.Rules;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.SocialMedias.Rules;
using Application.Services.AuthServices;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServiceRegistration(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped(typeof(ProgrammingLanguageBusinessRules));
            services.AddScoped(typeof(LanguageTechBusinessRules));
            services.AddScoped(typeof(AuthBusinessRules));
            services.AddScoped(typeof(SocialMediaBusinessRules));
            services.AddScoped(typeof(OperationClaimBusinessRules));

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddScoped<IAuthService, AuthManager>();

            return services;
        }
    }
}
