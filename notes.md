https://xunit.net/docs/getting-started/netcore/cmdline
https://learn.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests?pivots=mstest

```
dotnet test --filter "FullyQualifiedName=DemoTry.Three.TestMerchantPortal.AcceptedMessageShownWhenPaymentAccepted"

dotnet test --filter "FullyQualifiedName~DemoTry.Three"
```