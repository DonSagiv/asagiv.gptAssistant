using asagiv.Domain.Core.Interfaces;
using asagiv.Domain.Core.Models;
using StackExchange.Redis;

namespace asagiv.Infrastructure.gptAssistant.Models;

public class RedisClient(string Address)
{
    #region Fields
    private ConnectionMultiplexer _connectionMultiplexer;
    #endregion

    #region Properties
    public bool IsConnected { get; private set; }
    #endregion

    #region Methods
    public async Task<IResult> ConnectAsync()
    {
        if (Address is null)
        {
            return Result.Failure("No connection address set.");
        }

        try
        {
            _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(Address);

            IsConnected = true;

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(ex);
        }
    }

    public Task<IResult<RedisDatabase>> GetDatabaseAsync()
    {
        var database = _connectionMultiplexer.GetDatabase();

        return Result.SuccessAsync(new RedisDatabase(database));
    }
    #endregion
}
