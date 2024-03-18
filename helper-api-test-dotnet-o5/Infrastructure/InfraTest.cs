﻿using helper_api_dotnet_o5.Infrastructure;
using helper_api_dotnet_o5.Models.Bancos;
using helper_api_dotnet_o5.Models.Paises;

namespace helper_api_test_dotnet_o5.Infrastructure
{
    public class InfraTest
    {
        private const string ENDPOINTPaises = "https://servicodados.ibge.gov.br/api/v1";
        private const string ENDPOINTBancos = "https://brasilapi.com.br/api/banks/v1";

        [Fact]
        public async Task MetodoGET_DeveRetornarListaDePais()
        {
            // Arrange
            var helperAPI = new HelperAPI(ENDPOINTPaises);

            // Act
            var resultado = await helperAPI.MetodoGET<List<Pais>>("paises/BR");

            // Assert
            Assert.NotNull(resultado); 
            Assert.IsType<List<Pais>>(resultado);
        }

        [Fact]
        public async Task MetodoGET_DeveRetornarListaDeBanco()
        {
            // Arrange
            var helperAPI = new HelperAPI(ENDPOINTBancos);

            // Act
            var resultado = await helperAPI.MetodoGET<List<Banco>>(Route: string.Empty);

            // Assert
            Assert.NotNull(resultado);
            Assert.IsType<List<Banco>>(resultado);
        }

        [Fact]
        public async Task MetodoGET_DeveRetornarExcecaoQuandoEndPointInvalido()
        {
            // Arrange
            var endPointInvalido = "http://endereco.invalido";
            var helperAPI = new HelperAPI(endPointInvalido);

            // Act & Assert
            await Assert.ThrowsAsync<HttpRequestException>(async () => await helperAPI.MetodoGET<List<Pais>>("rota/teste"));
        }
    }
}
