using Moq;
using myfinance_web_netcore.Domain.Interfaces;
using myfinance_web_netcore.Infra;
using myfinance_web_netcore.Models;
using Xunit;

namespace myfinance_web_xunit.Domain
{
    public class TransacaoTest
    {
        private readonly Mock<IDAL> _DALMock = new();
        private readonly Mock<ITransacao> _TransacaoMock = new();

        [Fact]
        public void SeTentaInserirTransacao_QuandoModelValido_EntaoInsere()
        {
            //Arrange
            var model = new TransacaoModel()
            {
                Data = System.DateTime.Now,
                IdPlanoConta = 1,
                Tipo = "D",
                Historico = "Teste",
                Valor = 100
            };

            _TransacaoMock.Setup(x => x.Inserir(model)).Returns(1);
            //_TransacaoMock.Setup(x => x.Inserir(It.IsAny<TransacaoModel>())).Returns(1);

            //Act
            var result = _TransacaoMock.Object.Inserir(model);

            //Asserts
            _TransacaoMock.Verify(x => x.Inserir(model), Times.Once());
            Assert.True(result == 1);
        }
    }
}
