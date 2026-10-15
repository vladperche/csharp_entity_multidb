
#echo "!! Init: DOTNET (PRE) BUILD"
#dotnet build "./Entity.MultiDB.Migration/Entity.MultiDB.Migration.csproj" -c Release -o /app

echo "!! Init: MIGRATION ADD"
dotnet ef migrations add Migration_20261014225936 \
    --configuration Release \
    --project Entity.MultiDB.Infrastructure \
    --startup-project Entity.MultiDB.Migration \
    --verbose

#echo "!! Init: DOTNET (POS) BUILD"
#dotnet build "./Entity.MultiDB.Migration/Entity.MultiDB.Migration.csproj" -c Release -o /app

echo "!! Init: MIGRATION UPDATE"
dotnet ef database update \
    --configuration Release \
    --project Entity.MultiDB.Infrastructure \
    --startup-project Entity.MultiDB.Migration \
    --verbose


#echo "!! Init: DOTNET APP"
#cd /app
#dotnet "Entity.MultiDB.Migration.dll"

echo "!! DONE!"