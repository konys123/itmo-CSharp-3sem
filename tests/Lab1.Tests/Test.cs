using Itmo.ObjectOrientedProgramming.Lab1;
using Xunit;
using Xunit.Abstractions;

namespace Lab1.Tests;

public class Test
{
    private readonly ITestOutputHelper _testOutputHelper;

    public Test(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
    }

    [Fact]
    public void Scenario1()
    {
        var train = new Train(10, 50000);
        var s1 = new PowerMagneticPaths(100, 100);
        var s2 = new ConventionalMagneticPaths(100);
        System.Collections.ObjectModel.Collection<IRouteSection> sections = [s1, s2];
        var route = new Route(sections, 1, train, 500);
        Assert.True(route.TryToComplete());
        _testOutputHelper.WriteLine(train.Status());
    }

    [Fact]
    public void Scenario2()
    {
        var train = new Train(10, 50000);
        var s1 = new PowerMagneticPaths(100, 1000);
        var s2 = new ConventionalMagneticPaths(100);
        System.Collections.ObjectModel.Collection<IRouteSection> sections = [s1, s2];
        var route = new Route(sections, 1, train, 50);
        Assert.False(route.TryToComplete());
        _testOutputHelper.WriteLine(train.Status());
    }

    [Fact]
    public void Scenario3()
    {
        var train = new Train(10, 50000);
        var s1 = new PowerMagneticPaths(100, 100);
        var s2 = new ConventionalMagneticPaths(100);
        var s3 = new Station(10, 500);
        var s4 = new ConventionalMagneticPaths(100);
        System.Collections.ObjectModel.Collection<IRouteSection> sections = [s1, s2, s3, s4];
        var route = new Route(sections, 1, train, 500);
        Assert.True(route.TryToComplete());
        _testOutputHelper.WriteLine(train.Status());
    }

    [Fact]
    public void Scenario4()
    {
        var train = new Train(1, 5000);
        var s1 = new PowerMagneticPaths(100, 1000);
        var s2 = new Station(10, 500);
        var s3 = new ConventionalMagneticPaths(100);
        System.Collections.ObjectModel.Collection<IRouteSection> sections = [s1, s2, s3];
        var route = new Route(sections, 1, train, 50000);
        Assert.False(route.TryToComplete());
        _testOutputHelper.WriteLine(train.Status());
    }

    [Fact]
    public void Scenario5()
    {
        var train = new Train(1, 50000);
        var s1 = new PowerMagneticPaths(100, 1000);
        var s2 = new ConventionalMagneticPaths(100);
        var s3 = new Station(10, 50000);
        var s4 = new ConventionalMagneticPaths(100);
        System.Collections.ObjectModel.Collection<IRouteSection> sections = [s1, s2, s3, s4];
        var route = new Route(sections, 1, train, 500);
        Assert.False(route.TryToComplete());
        _testOutputHelper.WriteLine(train.Status());
    }

    [Fact]
    public void Scenario6()
    {
        var train = new Train(10, 50000);
        var s1 = new PowerMagneticPaths(100, 100);
        var s2 = new ConventionalMagneticPaths(100);
        var s3 = new PowerMagneticPaths(100, -50);
        var s4 = new Station(10, 30);
        var s5 = new ConventionalMagneticPaths(100);
        var s6 = new PowerMagneticPaths(100, 100);
        var s7 = new ConventionalMagneticPaths(100);
        var s8 = new PowerMagneticPaths(100, -100);
        System.Collections.ObjectModel.Collection<IRouteSection> sections = [s1, s2, s3, s4, s5, s6, s7, s8];
        var route = new Route(sections, 1, train, 30);
        Assert.True(route.TryToComplete());
        _testOutputHelper.WriteLine(train.Status());
    }

    [Fact]
    public void Scenario7()
    {
        var train = new Train(10, 500);
        var s1 = new ConventionalMagneticPaths(100);
        System.Collections.ObjectModel.Collection<IRouteSection> sections = [s1];
        var route = new Route(sections, 1, train, 50);
        Assert.False(route.TryToComplete());
        _testOutputHelper.WriteLine(train.Status());
    }

    [Fact]
    public void Scenario8()
    {
        var train = new Train(10, 50000);
        var s1 = new PowerMagneticPaths(100, 1000);
        var s2 = new PowerMagneticPaths(100, -2000);
        System.Collections.ObjectModel.Collection<IRouteSection> sections = [s1, s2];
        var route = new Route(sections, 1, train, 50);
        Assert.False(route.TryToComplete());
        _testOutputHelper.WriteLine(train.Status());
    }
}