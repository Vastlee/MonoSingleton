# MonoSingleton
Templated Singleton that can be extended by a MonoBehaviour for ease of creation.

# Example
class GameManager : MonoSingleton<GameManager> {
    public int SomeInt { get; set; }
}

From any other class
GameManager.Instance.SomeInt