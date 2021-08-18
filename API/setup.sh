#!/bin/bash

set -e

until dotnet-ef database update --no-build; do
	>&2 echo "PostgreSQL is starting up"
	sleep 1
done

>&2 echo "PostgreSQL is up - executing command"

dotnet-ef database update
