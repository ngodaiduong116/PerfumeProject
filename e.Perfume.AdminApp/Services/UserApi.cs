﻿using ePerfume.ViewModels.Common;
using ePerfume.ViewModels.System.Users;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace e.Perfume.AdminApp.Services
{
    public class UserApi : IUserApi
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _configuration;
        public UserApi(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
        }

        public async Task<string> Authenticate(LoginRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");

            var response = await client.PostAsync("/api/users/authenticate", httpContent);
            var token = await response.Content.ReadAsStringAsync();

            return token;
        }

        public async Task<PageResult<UserVm>> GetUsersPaging(GetUserPagingRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer" + request.BearerToken);
            var response = await client.GetAsync($"/api/users/paging?pageIndex={request.PageIndex}&pageSize={request.PageSize}&keyword={request.KeyWord}");

            var body = await response.Content.ReadAsStringAsync();
            var users = JsonConvert.DeserializeObject<PageResult<UserVm>>(body);

            return users;
        }

        public async Task<bool> RegisterUser(RegisterRequest request)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"/api/users", httpContent);
            return response.IsSuccessStatusCode;
        }
    }
}