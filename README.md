# Api.Client.MyAnimeList

This is a client for the MyAnimeList API. It is a simple client that allows you to interact with the MyAnimeList API.

## Installation

```bash
dotnet add package Api.Client.MyAnimeList
```

## Usage

Some usefull links are:
	
- [How to get a token](https://myanimelist.net/blog.php?eid=835707)
- [API documentation](https://myanimelist.net/apiconfig/references/api/v2)


Many examples can be found under Test.MyAnimeListApi project.

```csharp
using Api.Client.MyAnimeList;

var client = new ApiClient(Test.Default.MyAnimeListApiKey);

var anime = client.GetAnimeList("One Piece", limit: 1).Result;
```

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
