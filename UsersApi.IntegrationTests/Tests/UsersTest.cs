using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UsersApi.Application.Dtos;
using UsersApi.IntegrationTests.Helpers;
using UsersApi.Services.Models;
using Xunit;

namespace UsersApi.IntegrationTests.Tests
{
    /// <summary>
    /// CLasse de testes de integração para o endpoint /api/users
    /// </summary>
    public class UsersTest
    {
        [Fact]
        public async Task Test_Users_Create_ReturnsCreated()
        {
            var faker = new Faker("pt_BR");
            var request = new UserCreateRequestDto
            {
                Name = faker.Person.UserName,
                Email = faker.Internet.Email(),
                Password = "@Teste123",
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/users/create", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            var response = TestHelper.ReadResponse<UserCreateResponseDto>(result);

            response?.Should().NotBeNull();
            response?.Id.Should().NotBeNull();
            response?.Name.Should().Be(request.Name);
            response?.Email.Should().Be(request.Email);
            response?.Role.Should().Be("USER_ROLE");
        }

        [Fact]
        public async Task Test_Users_Create_ReturnsBadRequest()
        {
            var request = new UserCreateRequestDto
            {
                Name = "Usuario Default",
                Email = "usuariodefault@email.com",
                Password = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/users/create", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);

            var response = TestHelper.ReadResponse<ErrorResponseModel>(result);

            response?.Should().NotBeNull();
            response?.StatusCode.Should().Be(400);
            response?.Errors?
                .FirstOrDefault(e => e.Equals("O email informado já está cadastrado."))
                .Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Users_Auth_ReturnsOk()
        {
            var request = new UserAuthRequestDto
            {
                Email = "usuariodefault@email.com",
                Password = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/users/auth", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            var response = TestHelper.ReadResponse<UserAuthResponseDto>(result);

            response?.Should().NotBeNull();
            response?.Id.Should().NotBeNull();
            response?.Name.Should().NotBeNull();
            response?.Email.Should().Be(request.Email);
            response?.Role.Should().Be("USER_ROLE");
            response?.AccessToken?.Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Users_Auth_ReturnsBadRequest()
        {
            var faker = new Faker("pt_BR");
            var request = new UserAuthRequestDto
            {
                Email = faker.Internet.Email(),
                Password = "@Teste123"
            };

            var content = TestHelper.CreateContent(request);
            var result = await TestHelper.CreateClient.PostAsync("/api/users/auth", content);

            result.StatusCode
                .Should()
                .Be(HttpStatusCode.BadRequest);

            var response = TestHelper.ReadResponse<ErrorResponseModel>(result);

            response?.Should().NotBeNull();
            response?.StatusCode.Should().Be(400);
            response?.Errors?
                .FirstOrDefault(e => e.Equals("Usuário inválido. Acesso negado."))
                .Should().NotBeNull();
        }
    }
}
