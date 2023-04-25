namespace Core.Domain.Bases
{
	public abstract class BaseEntity<T>
	{
		public T Id { get; set; }
		public DateTime CreateDate { get; set; }
	}
}
