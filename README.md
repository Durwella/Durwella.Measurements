# Durwella.Measurements

[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](https://opensource.org/licenses/MIT)
[![NuGet](https://img.shields.io/nuget/v/Durwella.Measurements.svg)](https://www.nuget.org/packages/Durwella.Measurements/)

Utilities for using measurements with units.  Measurement dimensions are easily constructed from existing dimensions, and new dimensions of measurements with new units can be added.  Dimensions are tracked through operations - e.g. a length divided by a time yields a velocity.

## Using Existing Dimensions
> **Note**: All "Units" are defined as `UnitOfMeasurement`s with a value of 1.0 - e.g. `Units.Meters` is really a `UnitOfMeasurement` object with value 1.  In the code, `using Unit = Measurements.UnitOfMeasurement;` is often used so that units can be defined sightly more naturally.

Below is an example of using the existing units to calculate hydrostatic pressure in psi.

```csharp
UnitOfMeasurement g   = 9.80665 * Units.MetersPerSecondSquared;
UnitOfMeasurement rho = 1000 * Units.KilogramsPerCubicMeter;
UnitOfMeasurement h   = 10000 * Units.Feet;

UnitOfMeasurement pressure = rho * g * h;

Console.WriteLine(pressure.Type.Name + " = " + pressure.ToString(Units.PoundsPerSquareInch);
```
```
> Pressure = 4335.28 psi
```
The dimension of the resulting pressure is detected automatically by keeping track of the `UnitOfMeasurement`s tracked through the operations.

Note that units can be combined arbitrarily by multiplication and division.  The following code is equivalent to above:

```csharp
UnitOfMeasurement g   = 9.80665 * Units.Meters / (Units.Seconds * Units.Seconds);
UnitOfMeasurement rho = 1000 * Units.Kilograms / (Units.Meters * (Units.Meters * Units.Meters));
UnitOfMeasurement h   = 10000 * Units.Feet;

UnitOfMeasurement pressure = rho * g * h;

Console.WriteLine(pressure.Type.Name + " = " + pressure.ToString(Units.PoundsPerSquareInch);
```

> **Note**: Determination of unit labels is imperfect at the moment.  If `Console.WriteLine(pressure.ToString(Units.Pounds / (Units.Inches * Units.Inches)));` were used instead, the resulting output would be `Pressure = 4335.28 lb/in in`.  A named unit should be used for output if a specific resulting label is desired.

## Defining New Dimensions and Units
The user isn't restricted to the built-in dimensions and units.  Consider a new domain: cookie baking.

A baker needs to bake 12 gross cookies (1 gross = 144 cookies) by the end of the week.  If he wants to get all of the baking done in a standard 40-hour work week, at what rate must be bake cookies?

```csharp
// Define new dimensions: a cookie count, which is a base dimension, and a cookie rate, which is a compound dimension using the cookie count and time.
var cookieCount = new Dimension("Cookie Count");
var cookieRate = new Dimension("Cookie Rate", cookieCount / Dimensions.Time);

// Define some cookie units, including specifying the unit to be considered the default SI unit
var cookies = cookieCount.NewSIUnit("cookies");
var dozenCookies = new UnitOfMeasurement("dz", 12 * cookies);
var grossCookies = new UnitOfMeasurement("gr", 144 * cookies);

// Define a new time unit (for this application, workWeek = 40 * Units.Hours would work just as well)
var workWeek = new UnitOfMeasurement("work week", 40 * Units.Hours);

// The baker needs to bake 12 gross cookies
var totalCookies = 12 * grossCookies;
// rate = count / time
var cookiesRate =  totalCookies / workWeek;

Console.WriteLine(cookiesRate.ToString("{0:0.000} {1}"));
Console.WriteLine(cookiesRate.ToString(cookies / Units.Minutes));
Console.WriteLine(cookiesRate.ToString("{0:0.0} {1}", dozenCookies / Units.Hours));
```
```
> 0.012 cookies/s
> 0.72 cookies/min
> 3.6 dz/hr
```
Note that the `cookieRate` variable is unused (and unnecessary).  Because the rate is defined in terms of the base units (namely `cookieCount` and `Dimensions.Time`) which have SI units defined, the SI units for `cookieRate` are defined implicitly.  A definition for the SI unit of `cookieRate` is only required if a specific label (e.g. `cps`) is desired instead of the automatically-generated `cookies/s`.