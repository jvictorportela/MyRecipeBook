using FluentMigrator;

namespace MyRecipeBook.Infrastructure.Migrations.Versions;

[Migration(DatabaseVersions.TABLE_RECIPES, "Create table to save the recipes")]
public class Version0000002 : VersionBase
{
    //Relação de 1 pra N -> Será necessário criar uma tabela para N e a FK será hospedada na N
    //Relação de 1 pra N -> Onde N não é plural, a FK será hospedada na 1
    //Relação de 1 pra 1 -> Será posto como uma propriedade.
    public override void Up()
    {
        CreateTable("Recipes")
            .WithColumn("Title").AsString().NotNullable()
            .WithColumn("CookingTime").AsInt32().Nullable()
            .WithColumn("Difficulty").AsInt32().Nullable()
            .WithColumn("UserId").AsInt64().NotNullable().ForeignKey("FK_Recipe_User_Id", "Users", "Id");

        CreateTable("Ingredients")
            .WithColumn("Item").AsString().NotNullable()
            .WithColumn("RecipeId").AsInt64().NotNullable().ForeignKey("FK_Ingredient_Recipe_Id", "Recipes", "Id")
            .OnDelete(System.Data.Rule.Cascade); //Quando uma receita for deletada, os ingredientes também serão.

        CreateTable("Instructions")
            .WithColumn("Step").AsInt32().NotNullable()
            .WithColumn("Text").AsString(2000).NotNullable()
            .WithColumn("RecipeId").AsInt64().NotNullable().ForeignKey("FK_Instruction_Recipe_Id", "Recipes", "Id")
            .OnDelete(System.Data.Rule.Cascade); //Quando uma receita for deletada, as instruções também serão.

        CreateTable("DishTypes") //Tipos de pratos
            .WithColumn("Type").AsInt32().NotNullable()
            .WithColumn("RecipeId").AsInt64().NotNullable().ForeignKey("FK_DishType_Recipe_Id", "Recipes", "Id")
            .OnDelete(System.Data.Rule.Cascade); //Quando uma receita for deletada, as instruções também serão.
    }
}
