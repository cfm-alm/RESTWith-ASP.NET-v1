FROM mysql:8.2.0
EXPOSE 3306
COPY ./RestwithASPNETUdemy/db/migrations/ /home/database/
COPY ./RestwithASPNETUdemy/db/dataset/ /home/database/
COPY ./RestwithASPNETUdemy/ci/init_database.sh/ /docker-entrypoint-initdb.d/init_database.sh
