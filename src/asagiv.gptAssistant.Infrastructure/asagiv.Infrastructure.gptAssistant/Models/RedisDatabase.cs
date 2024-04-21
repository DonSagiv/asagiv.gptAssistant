using asagiv.Domain.Core.Interfaces;
using asagiv.Domain.Core.Models;
using StackExchange.Redis;

namespace asagiv.Infrastructure.gptAssistant.Models;

public class RedisDatabase
{
    #region Fields
    private readonly IDatabaseAsync _database;
    #endregion

    #region Constructor
    public RedisDatabase(IDatabaseAsync database)
    {
        _database = database;
    }
    #endregion

    #region Methods
    public async Task<IResult<string>> GetValueFromKeyAsync(string key)
    {
        var value = await _database.StringGetAsync(key);

        if (!value.HasValue)
        {
            return Result.Failure<string>(Error.FromDescription($"No value found for key {key}"));
        }

        return Result.Success(value.ToString());
    }

    public async Task<IResult> SetValueToKeyAsync(string key, string value)
    {
        await _database.StringSetAsync(key, value);

        return Result.Success();
    }
    #endregion
}
