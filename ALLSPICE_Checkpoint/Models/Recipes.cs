namespace ALLSPICE_Checkpoint_csharp.Models;
public class Recipes
{
 public int Id {get; set;} 
 public DataSet CreatedAt {get; set;}
 public DateTime UpdatedAt {get; set;}
 public string Title {get; set;}
public string Category {get; set;}
public string Instructions {get; set;}
public string ImgUrl {get; set;}
public string CreatorId {get; set; }
}