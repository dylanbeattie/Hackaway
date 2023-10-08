namespace Rockaway.WebApp.Data.Entities;

public class Artist {
	private readonly Guid id;
	private readonly string name;
	private readonly string description;
	private readonly string slug;
	public Guid Id { get; set; }
	[MaxLength(100)]
	public string Name { get; set; } = String.Empty;
	[MaxLength(500)]
	public string Description { get; set; } = String.Empty;

	[MaxLength(100)]
	[Unicode(false)]
	public string Slug { get; set; } = String.Empty;

	public Artist() { }

	public Artist(Guid id, string name, string description, string slug) {
		this.id = id;
		this.name = name;
		this.description = description;
		this.slug = slug;
	}
}