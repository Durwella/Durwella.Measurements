# Durwella.Measurements

Utilities for using measurements with units.  Measurement types are easily constructed from existing types, and new types of measurements with new units can be added.  Types are tracked through operations - e.g. a length divided by a time give a velocity.

## Using Existing Types
> **Note**: All "Units" are defined as `Measurement`s with a value of 1.0 - e.g. `Units.Meters` is really a `Measurement` object with value 1.  In the code, `using Unit = Measurements.Measurement;` is often used so that units can be defined sightly more naturally.

Below is an example of using the existing units to calculate hydrostatic pressure in psi.

```csharp
Measurement g   = 9.80665 * Units.MetersPerSecondSquared;
Measurement rho = 1000 * Units.KilogramsPerCubicMeter;
Measurement h   = 10000 * Units.Feet;

Measurement pressure = rho * g * h;

Console.WriteLine(pressure.Type.Name + " = " + pressure.ToString(Units.PoundsPerSquareInch);
```
```
> Pressure = 4335.28 psi
```
The measurement type of the resulting pressure is detected automatically by keeping track of the `Measurement`s tracked through the operations.

Note that units can be combined arbitrarily by multiplication and division.  The follow code is equivalent to above:

```csharp
Measurement g   = 9.80665 * Units.Meters / (Units.Seconds * Units.Seconds);
Measurement rho = 1000 * Units.Kilograms / (Units.Meters * (Units.Meters * Units.Meters));
Measurement h   = 10000 * Units.Feet;

Measurement pressure = rho * g * h;

Console.WriteLine(pressure.Type.Name + " = " + pressure.ToString(Units.PoundsPerSquareInch);
```

> **Note**: Determination of unit labels is imperfect at the moment.  If `Console.WriteLine(pressure.ToString(Units.Pounds / (Units.Inches * Units.Inches)));` were used instead, the resulting output would be `Pressure = 4335.28 lb/in in`.  A named unit should be used for output if a specific resulting label is desired.

## Defining New Types and Units
The user isn't restricted to the built-in measurement types and units.  Consider a new domain: cookie baking.

A baker needs to bake 12 gross cookies (1 gross = 144 cookies) by the end of the week.  If he wants to get all of the baking done in a standard 40-hour work week, at what rate must be bake cookies?

```csharp
// Define new measurement types: a cookie count, which is a base type, and a cookie rate, which is a compound type using the cookie count and time.
var cookieCount = new MeasurementType("Cookie Count");
var cookieRate = new MeasurementType("Cookie Rate", cookieCount / MeasurementTypes.Time);

// Define some cookie units, including specifying the unit to be considered the default SI unit
var cookies = cookieCount.NewSIUnit("cookies");
var dozenCookies = new Measurement("dz", 12 * cookies);
var grossCookies = new Measurement("gr", 144 * cookies);

// Define a new time unit (for this application, workWeek = 40 * Units.Hours would work just as well)
var workWeek = new Measurement("work week", 40 * Units.Hours);

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
Note that the `cookieRate` variable is unused (and unnecessary).  Because the rate is defined in terms of the base units (namely `cookieCount` and `MeasurementTypes.Time`) which have SI units defined, the SI units for `cookieRate` are defined implicitly.  A definition for the SI unit of `cookieRate` is only required if a specific label (e.g. `cps`) is desired instead of the automatically-generated `cookies/s`.