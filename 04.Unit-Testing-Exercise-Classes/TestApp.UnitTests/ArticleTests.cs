using NUnit.Framework;

using System;
using System.Text;

namespace TestApp.UnitTests;

public class ArticleTests
{
    private Article _article;

    [SetUp]
    public void SetUp()
    {
        _article = new Article();
    }

    [Test]
    public void Test_AddArticles_ReturnsArticleWithCorrectData()
    {
        // Arrange
        //"{title} {content} {author}"
        string[] input = new string[] { "GasPrices Content_1 Dido", "Whether Content_2 MinchoPaznikov", "Cars Content_3 ElonMusk" };

        // Act
        Article result = _article.AddArticles(input);

        // Assert
        Assert.That(result.ArticleList, Has.Count.EqualTo(3));
        Assert.That(result.ArticleList[0].Title, Is.EqualTo("GasPrices"));
        Assert.That(result.ArticleList[0].Content, Is.EqualTo("Content_1"));
        Assert.That(result.ArticleList[0].Author, Is.EqualTo("Dido"));
        Assert.That(result.ArticleList[1].Content, Is.EqualTo("Content_2"));
        Assert.That(result.ArticleList[2].Author, Is.EqualTo("ElonMusk"));
    }

    [Test]
    public void Test_GetArticleList_SortsArticlesByTitle()
    {
        // Arrange
        Article input = new Article();
        input.ArticleList.Add(new Article
        {
            Title = "GasPrices",
            Content = "Content_1",
            Author = "Dido"
        });
        input.ArticleList.Add(new Article
        {
            Title = "Whether",
            Content = "Content_2",
            Author = "MinchoPaznikov"
        });
        input.ArticleList.Add(new Article
        {
            Title = "Cars",
            Content = "Content_3",
            Author = "ElonMusk"
        });

        string printCriteria = "title";

        StringBuilder exected = new StringBuilder();
        exected.AppendLine("Cars - Content_3: ElonMusk");
        exected.AppendLine("GasPrices - Content_1: Dido");
        exected.Append("Whether - Content_2: MinchoPaznikov");

        // Act
        string result = _article.GetArticleList(input, printCriteria);

        // Assert
        Assert.That(result, Is.EqualTo(exected.ToString()));
    }

        [Test]
    public void Test_GetArticleList_ReturnsEmptyString_WhenInvalidPrintCriteria()
    {
        // Arrange
        Article input = new Article();
        input.ArticleList.Add(new Article
        {
            Title = "GasPrices",
            Content = "Content_1",
            Author = "Dido"
        });
        input.ArticleList.Add(new Article
        {
            Title = "Whether",
            Content = "Content_2",
            Author = "MinchoPaznikov"
        });
        input.ArticleList.Add(new Article
        {
            Title = "Cars",
            Content = "Content_3",
            Author = "ElonMusk"
        });

        string printCriteria = "invalid";

        // Act
        string result = _article.GetArticleList(input, printCriteria);

        // Assert
        Assert.That(result, Is.Empty);
    }
}
