namespace TJMT.Prova.Senior.Domain.ValueObjects
{
	public class CedulaStub
    {
		public static Cedula Dez { get; } = new Cedula(10M);
		public static Cedula Vinte { get; } = new Cedula(20M);
		public static Cedula Cinquenta { get; } = new Cedula(50M);
		public static Cedula Cem { get; } = new Cedula(100M);
	}
}
