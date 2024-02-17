using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using Blazored.LocalStorage;
using Client.Models;
using Client.Models.Enums;
using Client.Models.ReadModels;
using Client.Models.Requests.Account;
using Client.Models.Requests.Account.Commands;
using Client.Models.Responses.Accounts;
using Client.Services.Interfaces;
using Microsoft.AspNetCore.Components.Authorization;
using MoneyMinder.API.Requests.Accounts;
using MoneyMinderClient.Models;

namespace Client.Services;


    public class MoneyMinderAuthenticationStateProvider : AuthenticationStateProvider, IAccountService
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions =
            new()
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

        private readonly HttpClient _httpClient;

        private readonly ILocalStorageService _localStorage;

        private bool _authenticated = false;

        private readonly ClaimsPrincipal Unauthenticated =
            new(new ClaimsIdentity());
        
        
        public MoneyMinderAuthenticationStateProvider(IHttpClientFactory httpClientFactory , ILocalStorageService localStorage)
        {
            _httpClient = httpClientFactory.CreateClient("Auth");

            _localStorage = localStorage;

            AuthenticationStateChanged += OnAuthenticationStateChanged;
        }
        
        public async Task<Result> LoginAsync(LoginAccountRequest request)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("api/Account", request);
            
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }
            
            var response = await responseMessage.Content.ReadAsStringAsync();
            
            if (response == null)
            {
                return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }
            
            response = response.Remove(response.Length - 1);

            response = response.Remove(0, 1);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", response);
            await _localStorage.SetItemAsStringAsync("Token", response);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());

            return new Result { Succeeded = true };
        }
        

        public async Task<Result> RegisterAsync(CreateUserRequest request)
        {
            var responseMessage = await _httpClient.PutAsJsonAsync("api/Account", request);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }

            return new (){ Succeeded = true};
        }

        public async Task LogoutAsync()
        {
            await _localStorage.RemoveItemAsync("Token");
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
        public async Task<bool> CheckAuthenticationAsync()
        {
            await GetAuthenticationStateAsync();
            return _authenticated;
        }

        public async Task<Result> ClearNotifications()
        {
            var responseMessage = await _httpClient.PostAsync("api/Account/notifications/clear", null);

            if (!responseMessage.IsSuccessStatusCode)
            {
                return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }

            return new (){ Succeeded = true};
        }

        public async Task<string> GetToken()
            => await _localStorage.GetItemAsStringAsync("Token");

        

        public async Task<string> GetName()
        {
            var token = await _localStorage.GetItemAsStringAsync("Token");

            if (!string.IsNullOrEmpty(token))
            {
                var handler = new JwtSecurityTokenHandler();
                
                JwtSecurityToken? jsonToken = null;

                if (handler.CanReadToken(token))
                {
                    jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                }

                if (jsonToken != null)
                {
                    return jsonToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "";
                }
            }

            return "";

        }

        public Task<Role> GetRole()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> GetId()
        {
            throw new NotImplementedException();
        }

        public async Task<Result<GetPersonalInfoResponse>> GetPersonalInfo()
        {
            var responseMessage = await _httpClient.GetAsync($"api/Account/info"); 
        
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }
        
            var response = await responseMessage.Content.ReadFromJsonAsync<PersonalInfoModel>();
        
            if (response == null)
            {
                return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }

            return new (){ Succeeded = true, Response = new (response)};
        }

        public async Task<Result<GetNotificationsResponse>> GetNotifications()
        {
            var responseMessage = await _httpClient.GetAsync($"api/Account/notifications"); 
        
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }
            
            if (string.IsNullOrEmpty(await responseMessage.Content.ReadAsStringAsync()))
            {
                return new() { Succeeded = true, Response = new(null)};
            }
            
            var response = await responseMessage.Content.ReadFromJsonAsync<IEnumerable<NotificationModel>>();
        
            if (response == null)
            {
                return new (){ Succeeded = false, ErrorList = new() {"Response is null.", $"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }
            
            return new (){ Succeeded = true, Response = new (response)};
        }

        public async Task<Result> ChangePassword(ChangePasswordRequest request)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("api/Account/password", request);
        
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }
        
            return new (){ Succeeded = true };
        }

        public async Task<Result> ChangeName(ChangeNameRequest request)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("api/Account/name", request);
        
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }
        
            return new (){ Succeeded = true };
        }

        public async Task<Result> ChangePhoneNumber(ChangePhoneNumberRequest request)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("api/Account/phone", request);
        
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }
        
            return new (){ Succeeded = true };
        }

        public async Task<Result> ChangeAddress(ChangeAddressRequest request)
        {
            var responseMessage = await _httpClient.PostAsJsonAsync("api/Account/address", request);
        
            if (!responseMessage.IsSuccessStatusCode)
            {
                return new (){ Succeeded = false, ErrorList = new() {$"Status Code: {responseMessage.StatusCode}", $"Content: {await responseMessage.Content.ReadAsStringAsync()}"} };
            }
        
            return new (){ Succeeded = true };
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await _localStorage.GetItemAsStringAsync("Token");

            if (!string.IsNullOrEmpty(token))
            {
                
                
                var handler = new JwtSecurityTokenHandler();
                JwtSecurityToken? jsonToken = null;
                if (handler.CanReadToken(token))
                {
                    jsonToken = handler.ReadToken(token) as JwtSecurityToken;
                }
                 

                var claims = new List<Claim>();

                if (jsonToken != null)
                {
                    claims.AddRange(jsonToken.Claims);
                }

                var identity = new ClaimsIdentity(claims, "jwt");
                var user = new ClaimsPrincipal(identity);

                _authenticated = true;

                return new AuthenticationState(user);
            }
            
            _authenticated = false;
            return new AuthenticationState(Unauthenticated);
            
        }
        private async void OnAuthenticationStateChanged(Task<AuthenticationState> task)
        {
            var authenticationState = await task;
        
            // if (authenticationState is not null)
            // {
            //     //Role = authenticationState.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value ?? "";
            //     //Name = authenticationState.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value ?? "";
            //     //Console.WriteLine(Role, Name);
            // }
        }
    }
