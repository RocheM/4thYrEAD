import processing.net.*;
import java.util.Random;



Person me;
ArrayList<Person> friends;
JSONObject result;
String accessToken = "CAACEdEose0cBAMrP8KbZCD87QJDtftL8rqHQvcfyPUZC8m9rkmDvIoBMUKXyZBrLbUWUIjYsVDM9kxUOZBbtAIOjTDNY2AoHptiPuosvZAol8WIH8wKyVw6fXnAaPsatRZBNt8DfZC3GrBSZB2kRtb03ZARQBFietN95C0VSwKo917ZBNveyygmL8ZARCqBCOqo5fBe6v3d01eWQwZDZD";
 
void setup()
{
  result = loadJSONObject("https://graph.facebook.com/v2.5/me?fields=name%2Cfriends%7Bname%7D&access_token=" + accessToken);
  me = new Person(result.getString("name"), result.getString("id"), true);  
  friends = new ArrayList<Person>();
  friends.add(me);
  JSONArray arr = result.getJSONObject("friends").getJSONArray("data");
  
  for (int i = 0; i < arr.size(); i++){
    friends.add(new Person(arr.getJSONObject(i).getString("name"), arr.getJSONObject(i).getString("id"), false)); 
  }
  
  for (int i = 0; i < friends.size(); i++){
    println(friends.get(i).toString());
  }
  
  friends = getTotalFriends(friends);
  
  createCSVTable(friends);
  
}
 
void draw()
{

}

ArrayList<Person> getTotalFriends(ArrayList<Person> list){

  JSONObject obj;
  
  for (int i = 0; i < friends.size(); i++){
    
    try{
      obj = loadJSONObject("https://graph.facebook.com/v2.5/"+ list.get(i).getId() +"/friends?access_token=" + accessToken);
      int total = obj.getJSONObject("summary").getInt("total_count");
      Person p = list.get(i);
      p.setTotal(total);
      Random rand = new Random();
      int randomNum = rand.nextInt((friends.get(0).getTotalFriends() - 0) + 1) + 0;
      p.setCommonFriends(randomNum);
      
      if (!friends.get(i).isMe){
        randomNum = rand.nextInt((365 - 0) + 1) + 0;
        p.setDaysSinceLastSeen(randomNum);
      }
      else
        p.setDaysSinceLastSeen(0);
        
      list.set(i, p);
    }catch(Exception ex){
      
      Random rand = new Random();
      int randomNum = rand.nextInt((friends.get(0).getTotalFriends() - 0) + 1) + 0;
      Person p = list.get(i);
      println(p.toString());
      p.setTotal(randomNum);
      randomNum = rand.nextInt((randomNum- 0) + 1) + 0;
      p.setCommonFriends(randomNum);
      
      
      if (!friends.get(i).isMe){
        randomNum = rand.nextInt((365 - 0) + 1) + 0;
        p.setDaysSinceLastSeen(randomNum);
      }
      else
        p.setDaysSinceLastSeen(0);
        
        
      list.set(i, p);
    }
  }
  
  return list;
}

void createCSVTable(ArrayList<Person> friends){
  
  Table table = new Table();
  
  table.addColumn("id");
  table.addColumn("name");
  
  for (int i = 0; i < friends.size(); i++){
    
    TableRow newRow = table.addRow();
    newRow.setString("id", friends.get(i).getId());
    newRow.setString("name", friends.get(i).getName());
    newRow.setString("total", Integer.toString(friends.get(i).getTotalFriends()));
    newRow.setString("Friends in Common", Integer.toString(friends.get(i).getCommonFriends()));
    newRow.setString("Days Since Last Seen", Integer.toString(friends.get(i).getDaysSinceLastSeen()));
 }
  
  saveTable(table, "data/new.csv");

 }
 
class Person
{
 
  String name;
  String id;
  Boolean isMe;
  int totalFriends;
  int commonFriends;
  int daysSinceLastSeen;
  
  Person(String name, String id, Boolean isMe) {
    
    this.name = name;
    this.id = id;
    this.isMe = isMe;
  }
 
  public String toString  () {
    

    return "Name: " + name + "\nID: " + id + "\nisMe: " + Boolean.toString(isMe) + "\n";
  }
  
  public String getName(){
  
    return name;
  }
  
  public String getId(){
  
    return id;
  }
  
  public Boolean isMe(){
    return isMe;
  }
  
  public void setTotal(int totalFriends){
    this.totalFriends = totalFriends;
  }

  public int getTotalFriends(){
  
    return totalFriends;
  }
  
  public void setCommonFriends(int commonFriends){
    
     this.commonFriends = commonFriends;
  
  }
  
  public int getCommonFriends(){
  
      return commonFriends;
  }
  
  public int getDaysSinceLastSeen(){
  
      return daysSinceLastSeen;
  }
  
  public void setDaysSinceLastSeen(int daysSinceLastSeen){
    this.daysSinceLastSeen = daysSinceLastSeen;
  }
}