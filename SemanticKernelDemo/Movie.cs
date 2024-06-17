public class Movie
{
    [JsonPropertyName("Title")]
    public string Title { get; set; } = string.Empty;

    [JsonPropertyName("Year")]
    public string Year { get; set; } = string.Empty;

    [JsonPropertyName("Rated")]
    public string Rated { get; set; } = string.Empty;

    [JsonPropertyName("Released")]
    public string Released { get; set; } = string.Empty;

    [JsonPropertyName("Runtime")]
    public string Runtime { get; set; } = string.Empty;

    [JsonPropertyName("Genre")]
    public string Genre { get; set; } = string.Empty;

    [JsonPropertyName("Director")]
    public string Director { get; set; } = string.Empty;

    [JsonPropertyName("Writer")]
    public string Writer { get; set; } = string.Empty;

    [JsonPropertyName("Actors")]
    public string Actors { get; set; } = string.Empty;

    [JsonPropertyName("Plot")]
    public string Plot { get; set; } = string.Empty;

    [JsonPropertyName("Language")]
    public string Language { get; set; } = string.Empty;

    [JsonPropertyName("Country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("Awards")]
    public string Awards { get; set; } = string.Empty;

    [JsonPropertyName("Poster")]
    public string Poster { get; set; } = string.Empty;

    [JsonPropertyName("Ratings")]
    public List<Rating> Ratings { get; set; } = new List<Rating>();

    [JsonPropertyName("Metascore")]
    public string Metascore { get; set; } = string.Empty;

    [JsonPropertyName("imdbRating")]
    public string ImdbRating { get; set; } = string.Empty;

    [JsonPropertyName("imdbVotes")]
    public string ImdbVotes { get; set; } = string.Empty;

    [JsonPropertyName("imdbID")]
    public string ImdbID { get; set; } = string.Empty;

    [JsonPropertyName("Type")]
    public string Type { get; set; } = string.Empty;

    [JsonPropertyName("DVD")]
    public string DVD { get; set; } = string.Empty;

    [JsonPropertyName("BoxOffice")]
    public string BoxOffice { get; set; } = string.Empty;

    [JsonPropertyName("Production")]
    public string Production { get; set; } = string.Empty;

    [JsonPropertyName("Website")]
    public string Website { get; set; } = string.Empty;

    [JsonPropertyName("Response")]
    public string Response { get; set; } = string.Empty;
}

public class Rating
{
    [JsonPropertyName("Source")]
    public string Source { get; set; } = string.Empty;

    [JsonPropertyName("Value")]
    public string Value { get; set; } = string.Empty;
}
