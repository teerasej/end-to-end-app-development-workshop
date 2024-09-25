

using StackExchange.Redis;
using System.Text.Json;

Console.WriteLine("Redis Cache Sample");

// Replace the connection string with the your copy from the Azure portal
var connectionString = "your-redis-cache-connection-string";
var redisConnection = ConnectionMultiplexer.Connect(connectionString);
IDatabase db = redisConnection.GetDatabase();

bool wasSet = db.StringSet("favourite:flavor", "i-love-rocky-road");

string value = db.StringGet("favourite:flavor");
Console.WriteLine(value); // displays: ""i-love-rocky-road""

// Note: you can add more complex objects to the cache using JSON serialization

// Execute command
var executeResult = db.Execute("ping");
Console.WriteLine(executeResult.ToString()); // displays: "PONG"



redisConnection.Dispose();
redisConnection = null;