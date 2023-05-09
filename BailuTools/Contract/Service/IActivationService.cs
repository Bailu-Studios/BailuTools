namespace BailuTools.Contract.Service;

public interface IActivationService
{
    Task ActivateAsync(object activationArgs);
}
