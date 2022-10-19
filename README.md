Currency.Exchane.API

1. Change Currency.Exchange.API --> appsettings.json

(DefaultConnection,
LogConnection,
RedisConnection,
ApiKey)


2. Add-Migration InitialCreate -Context LogDbContext

3. update-database -Context LogDbContext

4. Add-Migration InitialCreate -Context CurrencyExchangeDbContext

5. update-database -Context CurrencyExchangeDbContext

6. Add new user by using ​/api​/Auth​/add-user (Example: admin, Ea1234. )

7. Login by using /api/Auth/login

8. Authorize with "Bearer jwtToken"

9. Try /api/ExchangeRate/get-rates , FromCurrency is mandatory but ToCurrencies could be empty or seperated with "," 
