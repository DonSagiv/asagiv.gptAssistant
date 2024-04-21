using asagiv.Infrastructure.gptAssistant.Models;
using static asagiv.gptAssistant.Infrastructure.Tests.RedisTestParameters;

namespace asagiv.gptAssistant.Infrastructure.Tests;

public class RedisTesting
{


    #region Methods
    [Fact]
    public async Task RedisClient_Should_ConnectAsync()
    {
        // Arrange
        var client = new RedisClient(CLIENT_ADDRESS);

        // Act
        var result = await client.ConnectAsync();

        // Assert
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task RedisClient_Should_GetDatabase()
    {
        // Arrange
        var client = new RedisClient(CLIENT_ADDRESS);
        await client.ConnectAsync();

        // Act
        var databaseResult = await client.GetDatabaseAsync();

        // Assert
        Assert.True(databaseResult.IsSuccess);
        Assert.NotNull(databaseResult.Value);
    }

    [Fact]
    public async Task RedisClient_Should_GetValue()
    {
        // Arrange
        var client = new RedisClient(CLIENT_ADDRESS);
        await client.ConnectAsync();
        var databaseResult = await client.GetDatabaseAsync();

        // Act
        var valueResult = await databaseResult.Value.GetValueFromKeyAsync(API_KEY);

        // Assert
        Assert.True(valueResult.IsSuccess);
        Assert.NotNull(valueResult.Value);
    }

    [Fact]
    public async Task RedisClient_Should_SetValue()
    {
        // Arrange
        var client = new RedisClient(CLIENT_ADDRESS);
        await client.ConnectAsync();
        var databaseresult = await client.GetDatabaseAsync();

        // Act
        var setResult = await databaseresult.Value.SetValueToKeyAsync("key_Test", "value_Test");

        // Assert
        Assert.True(setResult.IsSuccess);
    }
    #endregion
}