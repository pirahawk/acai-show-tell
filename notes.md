https://xunit.net/docs/getting-started/netcore/cmdline
https://learn.microsoft.com/en-us/dotnet/core/testing/selective-unit-tests?pivots=mstest

```
dotnet test --filter "FullyQualifiedName=DemoTry.Three.TestMerchantPortal.AcceptedMessageShownWhenPaymentAccepted"

dotnet test --nologo -v m --filter "FullyQualifiedName~DemoTry.One"  --no-build
dotnet test --nologo -v m --filter "FullyQualifiedName~DemoTry.Two" --no-build
dotnet test --nologo -v m --filter "FullyQualifiedName~DemoTry.Three" --no-build
dotnet test --nologo -v m --filter "FullyQualifiedName~DemoTry.Four" --no-build
```