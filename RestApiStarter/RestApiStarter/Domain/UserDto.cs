using Newtonsoft.Json;

namespace RestApiStarter.Domain;

[Serializable]
public class UserDto
{
  [JsonProperty("id")] public int ID;
  [JsonProperty("name")] public string Name;
  [JsonProperty("email")] public string Email;
}
