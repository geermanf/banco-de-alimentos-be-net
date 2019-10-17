//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Security.Claims;
//using System.Text;
//using System.Threading.Tasks;
//using AutoMapper;
//using Farmacity.Infrastructure.Extensions;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.OAuth;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Builder;
//using Microsoft.AspNetCore.Cors.Infrastructure;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.ApiExplorer;
//using Microsoft.AspNetCore.Mvc.Cors.Internal;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;
//using StructureMap;
//using Swashbuckle.AspNetCore.Swagger;

//namespace Farmacity.Infrastructure.Web
//{
//    public abstract class Startup : IOwinStartup
//    {
//        public readonly Func<ApiDescription, string> DefaultActionSorter = x =>
//        {
//            var path = x.RelativePath;

//            if (path.EndsWith("}") || path.EndsWith("/"))
//            {
//                // take off the last variable
//                var index = path.LastIndexOf('/');

//                if (index > -1)
//                    path = path.Substring(0, index);
//            }

//            return path;
//        };

//        public IInjectableScope Container
//        {
//            get;
//            private set;
//        }

//        //protected ILogger Logger { get; set; }
//        //protected ISecurityConfiguration SecurityConfig { get; private set; }
//        protected readonly IContainer InternalContainer = new Container();
//        protected ISecurityConfiguration SecurityConfig { get; private set; }

//        public virtual void Configuration(IApplicationBuilder app, IServiceCollection services)
//        {
//            ConfigureContainer();
//            //ConfigureLogging(app);
//            ConfigureMapping();
//            ConfigureSecurity(app, services);
//            ConfigureWebApi(services);
//        }

//        protected virtual void ConfigureContainer()
//        {
//            InternalContainer.ConfigureAppAssemblies();

//            Container = new StructureMapDependencyResolver(InternalContainer);
//        }

//        protected virtual void ConfigureMapping()
//        {
//            var config = new MapperConfiguration(x =>
//            {
//                x.AddProfilesFromAssemblyOf(GetType());
//            });

//            config.AssertConfigurationIsValid();

//            Container.Inject<IMapper>(config.CreateMapper());
//        }

//        protected virtual void ConfigureSecurity(IApplicationBuilder app, IServiceCollection services)
//        {
            
//            SecurityConfig = services.GetService<ISecurityConfiguration>(ISecurityConfiguration);

//            ConfigureCors(services);
//            app.UseCors("MyPolicy");
//            if (!SecurityConfig.AuthenticationEnabled)
//            {
//                //Logger<>.Debug("Authentication disabled.");

//                app.Use(async (context, next) =>
//                {
//                    var claims = new[]
//                    {
//                        new Claim("scope", "admin_globalbuilding"), //CLEAN
//                        new Claim("scope", "read_globalbuilding"),
//                        new Claim("scope", "write_globalbuilding"),
//                        new Claim("givenname", "Federico"),
//                        new Claim("sn", "Camps"),
//                        new Claim("samaccount_name", "fcamps"),
//                        new Claim("email", "fcamps@com")
//                    };

//                    context.Authentication.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(claims, "Test Authentication"));

//                    await next();
//                });

//                return;
//            }
//            else
//            {
//                // Enable the application to use a cookie to store information for the signed in user
//                // and to use a cookie to temporarily store information about a user logging in with a third party login provider
//                // Configure the sign in cookie
//                //app.UseCookieAuthentication(new CookieAuthenticationOptions
//                //{
//                //    AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
//                //    LoginPath = new PathString("/Account/Login"),
//                //    LogoutPath = new PathString("/Account/LogOff"),
//                //    ExpireTimeSpan = TimeSpan.FromMinutes(SecurityConfig.TokenExpirationMinutes),
//                //});

//                //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

//                //// Configure the application for OAuth based flow
//                //PublicClientId = "self";
//                //OAuthOptions = new OAuthAuthorizationServerOptions
//                //{
//                //    TokenEndpointPath = new PathString("/Token"),
//                //    Provider = new AppOAuthProvider(PublicClientId),
//                //    AuthorizeEndpointPath = new PathString("/Account/ExternalLogin"),
//                //    AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(SecurityConfig.TokenExpirationMinutes),
//                //    RefreshTokenProvider = new ApplicationRefreshTokenProvider(),
//                //    AllowInsecureHttp = !SecurityConfig.RequireSsl //Don't do this in production ONLY FOR DEVELOPING: ALLOW INSECURE HTTP!
//                //};

//                //// Enable the application to use bearer tokens to authenticate users
//                //app.UseOAuthBearerTokens(OAuthOptions);

//                //// Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
//                //app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

//                //// Enables the application to remember the second login verification factor such as phone or email.
//                //// Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
//                //// This is similar to the RememberMe option when you log in.
//                //app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);
//            }
//        }

//        protected virtual void ConfigureCors(IServiceCollection services)
//        {
//            if (SecurityConfig.CorsOrigins.IsEmpty())
//                services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
//                {
//                    builder.AllowAnyOrigin()
//                        .AllowAnyMethod()
//                        .AllowAnyHeader()
//                        .AllowAnyOrigin();
//                }));
//            else
//            {
//                services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
//                {
//                    builder.AllowAnyOrigin()
//                        .AllowAnyMethod()
//                        .AllowAnyHeader()
//                        .WithOrigins(SecurityConfig.CorsOrigins);
//                }));
//            }

            

//            services.AddMvc();
//            services.Configure<MvcOptions>(options =>
//            {
//                options.Filters.Add(new CorsAuthorizationFilterFactory("MyPolicy"));
//            });
//        }

//        public virtual void ConfigureWebApi(IServiceCollection services)
//        {
//            services.AddMvc(options =>
//                {
//                    if (SecurityConfig.AuthenticationEnabled)
//                        options.Filters.Add(typeof(AuthorizeAttribute));

//                    options.FormatterMappings.ClearMediaTypeMappingForFormat("XmlFormatter");
                   
//                })
//                .AddWebApiConventions();

//            //ConfigureHandlers(config.MessageHandlers);
//            //ConfigureOData(config);
//            //ConfigureRouting(config);
//            //ConfigureTracing(config);
//            //Configure(config);


//        }
//        protected virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
//        {
//        }

//        protected virtual void EnableSwagger(IServiceCollection services, string title, string description, string commentsPath = null)
//        {
//            services
//                .AddSwaggerGen(c =>
//                {
//                    c.SwaggerDoc("v1", new Info
//                        {
//                            Title = title,
//                            Version = "v1",
//                            Description = description,
//                            TermsOfService = "None",
//                            Contact = new Contact
//                            {
//                                Name = "Farmacity",
//                                Email = string.Empty,
//                                Url = "https://www.farmacity.com/"
//                            },
//                            License = new License
//                            {
//                                Name = "Farmacity",
//                                Url = "https://www.farmacity.com/"
//                            }
//                    }
//                    );
//                    c.DescribeAllEnumsAsStrings();

//                    if (!string.IsNullOrWhiteSpace(commentsPath) && File.Exists(commentsPath))
//                        c.IncludeXmlComments(commentsPath);
//                });
//        }
//    }
//}
