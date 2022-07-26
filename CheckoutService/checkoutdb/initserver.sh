# Wait to be sure that SQL Server came up
echo "starting sql server"
sleep 30s
echo "running sql script"
# Run the setup script to create the DB and the schema in the DB
# Note: make sure that your password matches what is in the Dockerfile
/opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P abc123!!@ -d master -i create-database.sql