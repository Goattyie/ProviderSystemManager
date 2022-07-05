using Microsoft.EntityFrameworkCore;
using ProviderSystemManager.DAL.Database;
using ProviderSystemManager.DAL.Queries;

namespace ProviderSystemManager.DAL.QueryCreators
{
    internal class QueryCreator
    {
        public static void Init(ProviderDbContext dbContext)
        {
            var query = new AbonentsByAbonentTypeQuery(dbContext);
            var query2 = new FirmsByOwnType(dbContext);
            var query3 = new FirmsByServiceRecievingDate(dbContext);
            var query4 = new ContractsInfoQuery(dbContext);
            var query5 = new ServiceInfoQuery(dbContext);
            var query6 = new ContractAbonentsEmailNotNullQuery(dbContext);
            var query7 = new FirmHaveServicesQuery(dbContext);
            var query8 = new FirmsByStartDateWithServicesQuery(dbContext);
            var query9 = new AbonentsByServiceRecievingDateQuery(dbContext);
            var query10 = new AbonentInfoQuery(dbContext);
            var query11 = new SumSizeFirmsQuery(dbContext);
            var query12 = new FirmsCountByOwnTypeQuery(dbContext);
            var query13 = new AbonentsByContractsSumQuery(dbContext);
            var query14 = new AbonentsByContractsSumAndDateQuery(dbContext);
            var query15 = new FirmsSumConnectionCostInflationQuery(dbContext);
            var query16 = new FirmsSumConnectionCostMoreAvgQuery(dbContext);
            var query17 = new MaskQuery(dbContext);
            var query18 = new СaseQuery(dbContext);
            var query19 = new UnionQuery(dbContext);
            var query20 = new InQuery(dbContext);
            var query21 = new NotInQuery(dbContext);

            dbContext.Database.ExecuteSqlRaw(query.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query2.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query3.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query4.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query5.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query6.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query7.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query8.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query9.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query10.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query11.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query12.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query13.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query14.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query15.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query16.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query17.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query18.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query19.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query20.CreateQuery);
            dbContext.Database.ExecuteSqlRaw(query21.CreateQuery);

            #region SEQUENCES

            dbContext.Database.ExecuteSqlRaw("CREATE SEQUENCE firms_seq");
            dbContext.Database.ExecuteSqlRaw("CREATE SEQUENCE abonents_seq");
            dbContext.Database.ExecuteSqlRaw("CREATE SEQUENCE abonent_types_seq");
            dbContext.Database.ExecuteSqlRaw("CREATE SEQUENCE contracts_seq");
            dbContext.Database.ExecuteSqlRaw("CREATE SEQUENCE own_types_seq");
            dbContext.Database.ExecuteSqlRaw("CREATE SEQUENCE services_seq");

            #endregion

            #region GRANDS

            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON firms TO abonent;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON services TO abonent;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON contracts TO abonent;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON abonents TO abonent;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON abonent_types TO abonent;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON own_types TO abonent;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON users TO abonent;");

            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON firms TO operator;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON services TO operator;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON contracts TO operator;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON abonents TO operator;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON abonent_types TO operator;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON own_types TO operator;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT ON users TO operator;");

            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON firms TO admin;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON services TO admin;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON contracts TO admin;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON abonents TO admin;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON abonent_types TO admin;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON own_types TO admin;");
            dbContext.Database.ExecuteSqlRaw("GRANT SELECT, DELETE, UPDATE, INSERT ON users TO admin;");

            //#endregion

            //#region TRIGGERS

            dbContext.Database.ExecuteSqlRaw("CREATE OR REPLACE FUNCTION users_after_update() RETURNS trigger AS $$ BEGIN IF OLD.role <> NEW.role THEN IF OLD.role = 1 THEN EXECUTE 'ALTER GROUP operator DROP USER ' || NEW.login; EXECUTE 'GRANT abonent TO ' || NEW.login; END IF; IF OLD.role = 2 THEN EXECUTE 'ALTER GROUP abonent DROP USER ' || NEW.login; EXECUTE 'GRANT operator TO ' || NEW.login; END IF; IF OLD.role = 0 THEN RAISE EXCEPTION 'Администаторов нельзя понижать в должности'; END IF; END IF; RETURN NEW; END; $$ LANGUAGE plpgsql SECURITY DEFINER;  CREATE TRIGGER users_after_update_trigger AFTER UPDATE ON users FOR EACH ROW EXECUTE PROCEDURE users_after_update();");
            dbContext.Database.ExecuteSqlRaw("CREATE OR REPLACE FUNCTION users_after_insert() RETURNS trigger AS $$ BEGIN IF NEW.role = 0 THEN EXECUTE 'GRANT admin TO ' || NEW.login; END IF; IF NEW.role = 1 THEN EXECUTE 'GRANT operator TO ' || NEW.login; END IF; IF NEW.role = 2 THEN EXECUTE 'GRANT abonent TO ' || NEW.login; END IF; RETURN NULL; END; $$ LANGUAGE plpgsql SECURITY DEFINER;  CREATE TRIGGER users_after_insert_trigger AFTER INSERT ON users FOR EACH ROW EXECUTE PROCEDURE users_after_insert();");
            dbContext.Database.ExecuteSqlRaw("CREATE OR REPLACE FUNCTION users_after_delete() RETURNS trigger AS $$ BEGIN EXECUTE 'DROP USER ' || OLD.login; RETURN NULL; END; $$ LANGUAGE plpgsql SECURITY DEFINER;  CREATE TRIGGER users_after_delete_trigger AFTER DELETE ON users FOR EACH ROW EXECUTE PROCEDURE users_after_delete();");
            dbContext.Database.ExecuteSqlRaw("CREATE OR REPLACE FUNCTION firms_before_delete() RETURNS trigger AS $$ BEGIN IF (SELECT COUNT(*) FROM (SELECT FROM contracts WHERE firm_id=OLD.id) p) <> 0 THEN RAISE EXCEPTION 'У данной фирмы еще есть контракты с пользователями'; END IF; RETURN NULL; END; $$ LANGUAGE plpgsql SECURITY DEFINER;  CREATE TRIGGER firms_before_delete_trigger BEFORE DELETE ON firms FOR EACH ROW EXECUTE PROCEDURE firms_before_delete();");
            dbContext.Database.ExecuteSqlRaw("CREATE OR REPLACE FUNCTION firms_before_insert() RETURNS trigger AS $$ BEGIN IF (SELECT COUNT(*) FROM (SELECT FROM firms WHERE name=NEW.name AND telephone=NEW.telephone) p) <> 0 THEN RAISE EXCEPTION 'Фирма с таким названием и номером уже существует'; END IF; RETURN NEW; END; $$ LANGUAGE plpgsql SECURITY DEFINER;  CREATE TRIGGER firms_before_insert_trigger BEFORE INSERT ON firms FOR EACH ROW EXECUTE PROCEDURE firms_before_insert();");
            dbContext.Database.ExecuteSqlRaw("CREATE OR REPLACE FUNCTION firms_before_update() RETURNS trigger AS $$ BEGIN IF (SELECT COUNT(*) FROM (SELECT FROM firms WHERE name=NEW.name AND telephone=NEW.telephone) p) <> 0 THEN RAISE EXCEPTION 'Фирма с таким названием и номером уже существует'; END IF; RETURN NEW; END; $$ LANGUAGE plpgsql SECURITY DEFINER;  CREATE TRIGGER firms_before_update_trigger BEFORE UPDATE ON firms FOR EACH ROW EXECUTE PROCEDURE firms_before_update();");
            dbContext.Database.ExecuteSqlRaw("CREATE FUNCTION firms_before_insert_increment() RETURNS trigger AS $$ BEGIN NEW.id := nextval('firms_seq'); RETURN NEW; END; $$ LANGUAGE plpgsql SECURITY DEFINER;  CREATE TRIGGER firms_before_insert_increment_trigger BEFORE INSERT ON firms FOR EACH ROW EXECUTE PROCEDURE firms_before_insert_increment();");

            //#endregion

            //#region SECURITY

            dbContext.Database.ExecuteSqlRaw("ALTER TABLE firms ENABLE ROW LEVEL SECURITY;");
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE abonents ENABLE ROW LEVEL SECURITY;");
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE contracts ENABLE ROW LEVEL SECURITY;");
            dbContext.Database.ExecuteSqlRaw("ALTER TABLE services ENABLE ROW LEVEL SECURITY;");

            //#endregion

            //#region POLICY

            dbContext.Database.ExecuteSqlRaw("CREATE POLICY firms_abonent ON firms TO abonent USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY contracts_abonent ON contracts TO abonent USING (abonent_id = (SELECT id FROM users WHERE login = CURRENT_USER));");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY services_abonent ON services TO abonent USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY abonents_abonent ON abonents TO abonent USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY abonent_types_abonent ON abonent_types TO abonent USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY own_types_abonent ON own_types TO abonent USING (TRUE);");

            dbContext.Database.ExecuteSqlRaw("CREATE POLICY firms_operator ON firms TO operator USING (id = (SELECT id FROM users WHERE login = CURRENT_USER));");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY contracts_operator ON contracts TO operator USING (firm_id = (SELECT id FROM users WHERE login = CURRENT_USER));");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY services_operator ON services TO operator USING (firm_id = (SELECT id FROM users WHERE login = CURRENT_USER));");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY abonents_operator ON abonents TO operator USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY abonent_types_operator ON abonent_types TO operator USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY own_types_operator ON own_types TO operator USING (TRUE);");

            dbContext.Database.ExecuteSqlRaw("CREATE POLICY firms_admin ON firms TO operator USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY contracts_admin ON contracts TO operator USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY services_admin ON services TO operator USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY abonents_admin ON abonents TO operator USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY abonent_types_admin ON abonent_types TO operator USING (TRUE);");
            dbContext.Database.ExecuteSqlRaw("CREATE POLICY own_types_admin ON own_types TO operator USING (TRUE);");

            #endregion
        }
    }
}
