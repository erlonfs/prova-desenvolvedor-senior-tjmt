using System;

namespace TJMT.Prova.Senior.Domain.ValueObjects
{
	public class Cedula
	{
		public decimal Valor { get; }

		public Cedula(decimal valor)
		{
			if (valor <= 0M) throw new ArgumentOutOfRangeException(nameof(valor));
			Valor = valor;
		}

		public override string ToString()
		{
			return $"R$ {Valor.ToString("N2")}";
		}
	}
}
