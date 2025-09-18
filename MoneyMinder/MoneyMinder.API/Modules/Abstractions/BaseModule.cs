using Carter;

namespace MoneyMinder.API.Modules.Abstractions;

public abstract class BaseModule : CarterModule
{
    public BaseModule(string path)
        : base($"/api{path}")
    {

    }
}