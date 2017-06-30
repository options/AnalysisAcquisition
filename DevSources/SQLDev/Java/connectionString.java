Query String
	String hostName = "analysisacqserver";
        String dbName = "analysisAcquitionDB";
        String user = "username@analysisacqserver";
        String password = "password";
      
Connection connection = null;
String url = "jdbc:sqlserver://analysisacqserver.database.windows.net:1433;database=analysisAcquitionDB;user=userName@analysisacqserver;password={your_password_here};encrypt=true;trustServerCertificate=false;hostNameInCertificate=*.database.windows.net;loginTimeout=30;";