--crear usuario y darle permisos
CREATE USER PRUEBA_TECNICA IDENTIFIED BY PRUEBA_TECNICA;
ALTER USER PRUEBA_TECNICA ACCOUNT UNLOCK;
GRANT CREATE SESSION to PRUEBA_TECNICA;
GRANT CONNECT, RESOURCE, DBA TO PRUEBA_TECNICA;