ALTER DATABASE WebStoreDB 
COLLATE Latin1_General_100_CI_AS_SC_UTF8;

USE WebStoreDB;

-- Создание пользователя Петра Поркера с ролью Owner
INSERT INTO Users (UserName, PasswordHash, Salt, FirstName, LastName, DoC, Address, Roles) VALUES
 ('SpiderMan', '$2a$11$ui9x64l0Is20qZrxnJLWIO5wRjEFrG0kOco7WXWF/1u821k2VOL26', '$2a$11$ui9x64l0Is20qZrxnJLWIO', 'Пётр', 'Поркер', '2024-02-23 15:18:35', 'Нью-Йорк, США', 'Owner'),

 ('SagiJ', '$2a$11$b1F1e6sX3z7DaXi5xdSCee5Apfi78Zt52W5cHJmRgrmrhDx2FIIiS', '$2a$11$b1F1e6sX3z7DaXi5xdSCee', 'Жанарбек', 'Сагалиев', '2024-02-23 15:25:22', 'Бишкек, Кыргызстан', 'Admin'),
 ('BekTok', '$11$3/kiTagwrld0SWbd1QzcCu9OGlvh.LfZn73CjPi4eGuvoNidRBLCi', '$2a$11$3/kiTagwrld0SWbd1QzcCu', 'Бектур', 'Токтобеков', '2024-02-23 15:42:59', 'Бишкек, Кыргызстан', 'Admin'),
 ('BekJen', '$11$ab0yW/.9nfeaQcQwEjaO8uyUjJwd/zYCFgNcqWzWYkUzYx7oEybAm', '$2a$11$ab0yW/.9nfeaQcQwEjaO8u', 'Бексултан', 'Женишбеков', '2024-02-23 15:49:39', 'Москва, Россия', 'Admin'),

 ('IvanIvanov', '$2a$11$dMIxoZCoXoR/jiaEU2vAzecx2Coyk1xjDAWBD7NfOqu9XWIxEloyS', '$2a$11$dMIxoZCoXoR/jiaEU2vAze', 'Иван', 'Иванов', '2024-02-23 16:09:49', 'Санкт-Петербург, Россия', 'User'),
 ('AlexSmir', '$2a$11$FkwEOHUzDgbd8FXIuMiLO.Lgzc5NJ0HnlBIkBU9NdG/1TQYMIzB7y', '$2a$11$FkwEOHUzDgbd8FXIuMiLO.', 'Алексей', 'Смирнов', '2024-02-23 16:09:49', 'Москва, Россия', 'User'),
 ('EmilAbd', '$2a$11$sIOFrV9EVPB9oRxEtZMC1Okz6ruQwf/G0.AYvgzhEeKFVzcKWBobW', '$2a$11$sIOFrV9EVPB9oRxEtZMC1O', 'Эмиль', 'Абдуллин', '2024-02-23 16:09:49', 'Астана, Казахстан', 'User'),
 ('KylychTok', '$2a$11$ouTLMAv6ghvZKvKFIl6CH.NbNckf.0zt50dO3btZtGcjdqjd.Vq6.', '$2a$11$ouTLMAv6ghvZKvKFIl6CH.', 'Кылычбек', 'Токтоматов', '2024-02-23 16:09:49', 'Бишкек, Кыргызстан', 'User'),
 ('NursultanN', '$2a$11$DT1eOFwFuRBh7gS47YY2QeJZarnUg97Va4EK/clylZST3NWr4FDqy', '$2a$11$DT1eOFwFuRBh7gS47YY2Qe', 'Нурсултан', 'Назарбаев', '2024-02-23 16:09:49', 'Нур-Султан, Казахстан', 'User'),
 ('AiTemir', '$2a$11$lO99SeEbgrUkpysL4Ko6ZuhkT7Ae.c1t/CWrJ3.n/gu6Ot1G8DSoe', '$2a$11$lO99SeEbgrUkpysL4Ko6Zu', 'Айгерим', 'Темирова', '2024-02-23 16:09:49', 'Алматы, Казахстан', 'User'),
 ('MarySmir', '$2a$11$p0BM0Tb/4kmfDL.DjZ1iVepxF2GYvcPWFBmxe5D20wpHAw5q5xAZu', '$2a$11$p0BM0Tb/4kmfDL.DjZ1iVe', 'Мария', 'Смирнова', '2024-02-23 16:09:49', 'Санкт-Петербург, Россия', 'User'),
 ('BatyrKas', '$2a$11$TjqUlxZ05QA2FqbJYnLp..WuDqQOJMOml72x1NZCbu0MQYRQuHh8q', '$2a$11$TjqUlxZ05QA2FqbJYnLp..', 'Баатыр', 'Касымов', '2024-02-23 16:09:49', 'Ташкент, Узбекистан', 'User'),
 ('AiTurgan', '$2a$11$ZufCf.K/vtI59aJB7hmc6uNzCJTKIIgaIhU/urnvu8cTFojSRvsQi', '$2a$11$ZufCf.K/vtI59aJB7hmc6u', 'Айдана', 'Турганбаева', '2024-02-23 16:09:49', 'Алматы, Казахстан', 'User'),
 ('AliAliev', '$2a$11$KzA02YtPX0jNGz4u2sxAre8qM.JAX3IV4tNLP0z15GYEj/x/lAteW', '$2a$11$KzA02YtPX0jNGz4u2sxAre', 'Алишер', 'Алиев', '2024-02-23 16:09:49', 'Баку, Азербайджан', 'User'),
 ('AiMukh', '$2a$11$ALR0voaus.4l6Pjayz8wT.PTOcE3cm05oaVGa7kb3Y0BHQYfJGlaO', '$2a$11$ALR0voaus.4l6Pjayz8wT.', 'Айдар', 'Мухамеджанов', '2024-02-23 16:09:49', 'Астана, Казахстан', 'User'),
 ('ElKas', '$2a$11$EzKegNQQk2WKED2d0fUm4O8Yj5ddy3R9LRDZ2dTCL8LtrLr6dq/me', '$2a$11$EzKegNQQk2WKED2d0fUm4O', 'Эльвира', 'Касымова', '2024-02-23 16:09:49', 'Бишкек, Кыргызстан', 'User'),
 ('LenaPetro', '$2a$11$mzVImzYgGpHpwdwZFWEef.jf1xJHWGg0INXzUT1dQf.il6A8RblhO', '$2a$11$mzVImzYgGpHpwdwZFWEef.', 'Елена', 'Петрова', '2024-02-23 16:09:49', 'Москва, Россия', 'User'),
 ('DenisS', '$2a$11$dYVUk6zQcYmlckjsJU8bFe4K7lNRJbBo0ta6L8as/VysAK1rAkmEe', '$2a$11$dYVUk6zQcYmlckjsJU8bFe', 'Денис', 'Семенов', '2024-02-23 16:09:49', 'Киев, Украина', 'User'),
 ('AiZada', '$2a$11$nzwTgL0hZSryNJnzqp2/w.j6RwWcqNKepDqA6ze4mTl55YKVjx27C', '$2a$11$nzwTgL0hZSryNJnzqp2/w.', 'Айзада', 'Темирова', '2024-02-23 16:09:49', 'Ташкент, Узбекистан', 'User');
