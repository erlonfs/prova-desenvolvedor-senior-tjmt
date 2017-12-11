using FluentAssertions;
using System;
using Xunit;

namespace TJMT.Prova.Senior.Domain.Tests
{
	public class CaixaEletronicoTests
	{
		private readonly CaixaEletronico _caixaEletronico = new CaixaEletronico();

		[Fact]
		public void Quando_sacar_um_valor_negativo_devera_lancar_exception()
		{
			Action act = () => _caixaEletronico.Sacar(-5M);
			Assert.Throws<InvalidOperationException>(act);
		}

		[Fact]
		public void Quando_sacar_um_valor_que_nao_possue_cedulas_disponiveis_devera_lancar_exception()
		{
			Action act = () => _caixaEletronico.Sacar(45M);
			Assert.Throws<InvalidOperationException>(act);
		}

		[Fact]
		public void Quando_sacar_150_reais_devera_retornar_duas_cedulas()
		{
			var saque = _caixaEletronico.Sacar(150M);

			saque.Count.Should().Be(2);
		}
	}
}
