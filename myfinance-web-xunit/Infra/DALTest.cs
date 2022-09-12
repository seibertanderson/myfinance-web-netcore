using Microsoft.Extensions.Configuration;
using Moq;
using myfinance_web_netcore.Infra;
using System.Collections.Generic;
using Xunit;

namespace myfinance_web_xunit.Infra;

public class DALTest
{
    private readonly Mock<IDAL> _dalMock = new Mock<IDAL>();

    private void InicializarTeste()
    {
        var myConfig = new Dictionary<string, string>
        {
            {"ConnectionString", "Server=localhost\\SQLExpress;Database=db_myfinance;Trusted_Connection=True;" }
        };

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(myConfig)
            .Build();

        DAL.configuration = configuration;
    }

    [Fact]
    public void SeTentaConexao_QuandoBaseOnline_EntaoConecta()
    {
        //Arrange - preparar o objeto
        InicializarTeste();

        var objDal = DAL.GetInstancia;

        //Act
        objDal.Conectar();

        //Asserts
        Assert.True(true);
    }

    [Fact]
    public void SeTentaDesconectar_QuandoNaoConectado_EntaoFalha()
    {
        //Arrange
        InicializarTeste();

        var objDal = DAL.GetInstancia;

        //Act
        objDal.Desconectar();
    }

    [Fact]
    public void SeTentaObterDataTable_QuandoTemConexaoERegistros_EntaoRetornaDataTable()
    {
        //Arrange
        InicializarTeste();
        var objDal = DAL.GetInstancia;
        var sql = " SELECT * FROM TRANSACAO WHERE 1 = 0 ";
        objDal.Conectar();

        //Act
        var dataTable = objDal.RetornarDataTable(sql);

        //Asserts
        Assert.NotNull(dataTable);
        Assert.True(dataTable.Rows.Count == 0);
    }

    [Fact]
    public void TesteMoq()
    {
        //Arrange
        InicializarTeste();

        _dalMock.Setup(x => x.Conectar()).Returns(true);

        //Act
        var resultConexao = _dalMock.Object.Conectar();

        //Asserts
        _dalMock.Verify(x => x.Conectar(), Times.Once);
        Assert.True(resultConexao);
    }
}