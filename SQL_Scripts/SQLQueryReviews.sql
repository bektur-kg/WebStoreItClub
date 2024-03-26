USE WebStoreDB;

-- Добавление отзывов для смартфонов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('John Doe', 'The phone exceeded my expectations. Great performance and camera quality!', 9, 1, 1), -- iPhone 13
('Alice Smith', 'I`m satisfied with this phone. Good value for money.', 7, 2, 2), -- Samsung Galaxy S22
('Bob Johnson', 'Fast and responsive, great user experience.', 8, 3, 3), -- Google Pixel 6
('Emma Davis', 'Solid build quality, but could use some improvements in the camera department.', 7, 4, 4), -- OnePlus 9 Pro
('Michael Wilson', 'Amazing gaming experience, stunning display.', 9, 5, 5); -- ASUS ROG Phone 5

-- Добавление отзывов для ноутбуков
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Sarah Brown', 'Sleek design, but battery life could be better.', 7, 6, 6), -- MacBook Pro 2022
('Kevin Lee', 'Powerful performance, great for gaming and productivity.', 9, 7, 7), -- Dell XPS 15
('Jennifer Taylor', 'Lightweight and portable, perfect for traveling.', 8, 8, 8), -- HP Spectre x360
('David Martinez', 'Excellent keyboard and trackpad, but display could be brighter.', 8, 9, 9), -- Lenovo ThinkPad X1 Carbon
('Karen Clark', 'Beautiful display, but the speakers could be better.', 7, 10, 10); -- Microsoft Surface Laptop 4

-- Добавление отзывов для планшетов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Alex Johnson', 'Great tablet for media consumption, love the AMOLED display.', 8, 11, 11), -- iPad Air
('Emily White', 'Fast performance, but the battery life could be longer.', 7, 12, 12), -- Samsung Galaxy Tab S8
('Daniel Garcia', 'Versatile device, perfect for both work and entertainment.', 9, 13, 13), -- Microsoft Surface Pro 8
('Sophia Rodriguez', 'Beautiful design, but the software experience is lacking.', 7, 14, 14), -- Lenovo Tab P11 Pro
('James Moore', 'Affordable option with decent performance, good value for money.', 7, 15, 15); -- Amazon Fire HD 10

-- Добавление отзывов для рубашек
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Olivia Brown', 'Comfortable fabric, but the sizing runs small.', 7, 16, 16), -- Crew Neck T-Shirt
('William Wilson', 'Nice fit and quality, good for everyday wear.', 8, 17, 17), -- V-Neck T-Shirt
('Ava Martinez', 'Stylish design, but the fabric wrinkles easily.', 7, 18, 18), -- Polo Shirt
('Ethan Taylor', 'Classic style, but the buttons are a bit loose.', 7, 19, 19), -- Button-Down Shirt
('Charlotte Anderson', 'Warm and cozy, perfect for chilly days.', 9, 20, 20); -- Flannel Shirt

-- Добавление отзывов для джинсов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Noah Garcia', 'Great fit, but the fabric is a bit stiff.', 8, 21, 21), -- Skinny Jeans
('Sophia Rodriguez', 'Comfortable and stylish, love the slim fit.', 9, 22, 22), -- Slim Fit Jeans
('Mason Martinez', 'Classic style, but the leg opening is too wide.', 7, 23, 23), -- Straight Leg Jeans
('Isabella Moore', 'Flattering fit, but the length is too long.', 8, 24, 24), -- Bootcut Jeans
('Liam Clark', 'Comfortable waistband, but the fabric stretches out over time.', 7, 25, 25); -- Relaxed Fit Jeans


-- Добавление отзывов для смартфонов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Пётр Поркер', 'Отличный смартфон! Очень доволен покупкой.', 9, 1, 1), -- iPhone 13
('Жанарбек Сагалиев', 'Хороший телефон за свои деньги.', 8, 2, 2), -- Samsung Galaxy S22
('Бектур Токтобеков', 'Прекрасный аппарат, отличная камера!', 9, 3, 3), -- Google Pixel 6
('Иван Иванов', 'Удобный и быстрый телефон, но аккумулятор мог бы быть лучше.', 7, 4, 4), -- OnePlus 9 Pro
('Алексей Смирнов', 'Отличное устройство для игр и развлечений.', 9, 5, 5); -- ASUS ROG Phone 5

-- Добавление отзывов для ноутбуков
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Баатыр Касымов', 'Мощный ноутбук с отличным экраном!', 9, 6, 6), -- MacBook Pro 2022
('Айгерим Темирова', 'Легкий и компактный ноутбук, отлично подходит для путешествий.', 8, 7, 7), -- Dell XPS 15
('Алишер Алиев', 'Отличное сочетание производительности и портативности.', 9, 8, 8), -- HP Spectre x360
('Айдана Турганбаева', 'Удобная клавиатура и яркий дисплей.', 8, 9, 9), -- Lenovo ThinkPad X1 Carbon
('Айдар Мухамеджанов', 'Компактный и мощный ноутбук, отлично подходит для работы.', 9, 10, 10); -- Microsoft Surface Laptop 4

-- Добавление отзывов для планшетов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Нурсултан Назарбаев', 'Отличный планшет для чтения и просмотра видео.', 8, 11, 11), -- iPad Air
('Айзада Темирова', 'Быстрый и удобный планшет, отлично подходит для работы.', 9, 12, 12), -- Samsung Galaxy Tab S8
('Айдана Турганбаева', 'Универсальное устройство для работы и развлечений.', 8, 13, 13), -- Microsoft Surface Pro 8
('Айгерим Темирова', 'Красивый дизайн, но требуется улучшение программного обеспечения.', 7, 14, 14), -- Lenovo Tab P11 Pro
('Айдар Мухамеджанов', 'Недорогое устройство с достойной производительностью.', 8, 15, 15); -- Amazon Fire HD 10

-- Добавление отзывов для рубашек
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Елена Петрова', 'Отличная рубашка, качественный материал.', 9, 16, 16), -- Crew Neck T-Shirt
('Денис Семенов', 'Хорошая посадка и стильный дизайн.', 8, 17, 17), -- V-Neck T-Shirt
('Айзада Темирова', 'Удобная и модная рубашка, отлично сидит.', 9, 18, 18), -- Polo Shirt
('Айдана Турганбаева', 'Классический стиль, но кнопки немного болтаются.', 7, 19, 19), -- Button-Down Shirt
('Айгерим Темирова', 'Теплая и уютная рубашка, идеальна для прохладных дней.', 9, 20, 20); -- Flannel Shirt

-- Добавление отзывов для джинсов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Кылычбек Токтоматов', 'Отличная посадка, но ткань немного жесткая.', 8, 21, 21); -- Skinny Jeans

-- Добавление отзывов для смартфонов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('John Doe', 'Отличный телефон, превзошел мои ожидания. Отличная производительность и качество камеры!', 9, 5, 1), -- iPhone 13
('Alice Smith', 'Я доволен этим телефоном. Хорошее соотношение цены и качества.', 7, 6, 2), -- Samsung Galaxy S22
('Bob Johnson', 'Быстрый и отзывчивый, отличный пользовательский опыт.', 8, 7, 3), -- Google Pixel 6
('Emma Davis', 'Качественный корпус, но можно было бы улучшить камеру.', 7, 8, 4), -- OnePlus 9 Pro
('Michael Wilson', 'Удивительный игровой опыт, потрясающий дисплей.', 9, 9, 5); -- ASUS ROG Phone 5

-- Добавление отзывов для ноутбуков
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Sarah Brown', 'Строгий дизайн, но время автономной работы могло бы быть лучше.', 7, 10, 6), -- MacBook Pro 2022
('Kevin Lee', 'Мощная производительность, отлично подходит для игр и работы.', 9, 11, 7), -- Dell XPS 15
('Jennifer Taylor', 'Легкий и портативный, идеально подходит для путешествий.', 8, 12, 8), -- HP Spectre x360
('David Martinez', 'Отличная клавиатура и тачпад, но можно было бы улучшить яркость дисплея.', 8, 13, 9), -- Lenovo ThinkPad X1 Carbon
('Karen Clark', 'Прекрасный дисплей, но колонки могли бы быть лучше.', 7, 14, 10); -- Microsoft Surface Laptop 4

-- Добавление отзывов для планшетов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Alex Johnson', 'Отличный планшет для потребления медиа, нравится дисплей AMOLED.', 8, 15, 11), -- iPad Air
('Emily White', 'Быстрая производительность, но время автономной работы могло бы быть длиннее.', 7, 16, 12), -- Samsung Galaxy Tab S8
('Daniel Garcia', 'Универсальное устройство, идеально подходит как для работы, так и для развлечений.', 9, 17, 13), -- Microsoft Surface Pro 8
('Sophia Rodriguez', 'Прекрасный дизайн, но опыт использования программного обеспечения оставляет желать лучшего.', 7, 18, 14), -- Lenovo Tab P11 Pro
('James Moore', 'Доступный вариант с приличной производительностью, хорошее соотношение цены и качества.', 7, 19, 15); -- Amazon Fire HD 10

-- Добавление отзывов для рубашек
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Olivia Brown', 'Удобная ткань, но размеры маломерят.', 7, 20, 16), -- Crew Neck T-Shirt
('William Wilson', 'Хорошая посадка и качество, подходит для повседневной носки.', 8, 21, 17), -- V-Neck T-Shirt
('Ava Martinez', 'Стильный дизайн, но ткань складывается.', 7, 22, 18), -- Polo Shirt
('Ethan Taylor', 'Классический стиль, но пуговицы немного шаткие.', 7, 23, 19), -- Button-Down Shirt
('Charlotte Anderson', 'Тепло и уютно, идеально для прохладных дней.', 9, 24, 20); -- Flannel Shirt

-- Добавление отзывов для джинсов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Noah Garcia', 'Отличная посадка, но ткань немного жесткая.', 8, 25, 21), -- Skinny Jeans
('Sophia Rodriguez', 'Удобные и стильные, нравится узкий крой.', 9, 26, 22), -- Slim Fit Jeans
('Mason Martinez', 'Классический стиль, но ширина штанин слишком большая.', 7, 27, 23), -- Straight Leg Jeans
('Isabella Moore', 'Плоская посадка, но длина слишком длинная.', 8, 28, 24), -- Bootcut Jeans
('Liam Clark', 'Удобный пояс, но ткань тянется со временем.', 7, 29, 25); -- Relaxed Fit Jeans


-- Добавление отзывов для смартфонов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Ivan Ivanov', 'Great phone, powerful performance.', 9, 16, 1), -- iPhone 13
('Alex Smirnov', 'Satisfied with the overall performance.', 8, 17, 2), -- Samsung Galaxy S22
('Emil Abdullin', 'Fast and reliable, love the camera quality.', 9, 18, 3), -- Google Pixel 6
('Kylych Toktomatov', 'Decent phone for the price, but battery life could be better.', 7, 19, 4), -- OnePlus 9 Pro
('Nursultan Nazarbayev', 'Impressive performance, good value for money.', 8, 20, 5); -- ASUS ROG Phone 5

-- Добавление отзывов для ноутбуков
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Ai Temirova', 'Love the sleek design and fast performance.', 9, 21, 6), -- MacBook Pro 2022
('Mary Smirnova', 'Excellent laptop for work and entertainment.', 9, 22, 7), -- Dell XPS 15
('Batyr Kasymov', 'Solid build quality, but a bit heavy for travel.', 8, 23, 8), -- HP Spectre x360
('Ai Turganbayeva', 'Great keyboard and trackpad, but battery life could be longer.', 8, 24, 9), -- Lenovo ThinkPad X1 Carbon
('Ali Aliev', 'Sleek design, but the display could be brighter.', 7, 25, 10); -- Microsoft Surface Laptop 4

-- Добавление отзывов для планшетов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Ai Mukhamedzhanov', 'Good tablet for everyday use, responsive touch screen.', 8, 26, 11), -- iPad Air
('Elvira Kasymova', 'Fast performance, but a bit pricey compared to competitors.', 8, 27, 12), -- Samsung Galaxy Tab S8
('Lena Petrova', 'Versatile device, perfect for work and entertainment.', 9, 28, 13), -- Microsoft Surface Pro 8
('Denis Semenov', 'Stylish design, but software experience could be smoother.', 7, 29, 14), -- Lenovo Tab P11 Pro
('Ai Zadatimirova', 'Affordable option with decent performance.', 7, 30, 15); -- Amazon Fire HD 10

-- Добавление отзывов для рубашек
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Ai Zadatimirova', 'Great fit and comfortable fabric.', 9, 26, 16), -- Crew Neck T-Shirt
('Ali Aliev', 'Nice quality, fits perfectly.', 8, 27, 17), -- V-Neck T-Shirt
('Ai Mukhamedzhanov', 'Stylish design, but fabric wrinkles easily.', 7, 28, 18), -- Polo Shirt
('Elvira Kasymova', 'Classic style, but a bit tight around the chest.', 7, 29, 19), -- Button-Down Shirt
('Lena Petrova', 'Warm and cozy, perfect for winter.', 9, 30, 20); -- Flannel Shirt

-- Добавление отзывов для джинсов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Denis Semenov', 'Great fit and comfortable to wear.', 9, 26, 21), -- Skinny Jeans
('Ai Zadatimirova', 'Love the slim fit, stylish and comfortable.', 9, 27, 22), -- Slim Fit Jeans
('Ali Aliev', 'Classic style, but the length is too long.', 7, 28, 23), -- Straight Leg Jeans
('Ai Mukhamedzhanov', 'Good quality, but a bit tight around the waist.', 8, 29, 24), -- Bootcut Jeans
('Elvira Kasymova', 'Comfortable waistband, but the fabric is a bit stiff.', 8, 30, 25); -- Relaxed Fit Jeans

-- Добавление отзывов для платьев
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Denis Semenov', 'Beautiful dress, fits perfectly.', 9, 26, 26), -- Evening Gown
('Ai Zadatimirova', 'Love the design, perfect for summer.', 9, 27, 27), -- Sundress
('Ali Aliev', 'Elegant and stylish, received many compliments.', 8, 28, 28), -- Cocktail Dress
('Ai Mukhamedzhanov', 'Comfortable and flattering, great for any occasion.', 9, 29, 29), -- Maxi Dress
('Elvira Kasymova', 'High-quality fabric, love the fit.', 8, 30, 30); -- Bodycon Dress

-- Добавление отзывов для мяса
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Ai Zadatimirova', 'Fresh and delicious, great for grilling.', 9, 26, 31), -- Beef Steak
('Ali Aliev', 'Tender and juicy, perfect for roasting.', 8, 27, 32), -- Pork Chop
('Ai Mukhamedzhanov', 'Great quality, flavorful and well-marbled.', 9, 28, 33), -- Lamb Rack
('Elvira Kasymova', 'Lean and tasty, ideal for stewing.', 8, 29, 34), -- Chicken Breast
('Lena Petrova', 'Highly recommend, excellent taste and texture.', 9, 30, 35); -- Salmon Fillet

-- Добавление отзывов для сладостей
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Denis Semenov', 'Delicious and addictive, couldn`t stop eating.', 9, 26, 36), -- Chocolate Truffles
('Ai Zadatimirova', 'Perfect balance of sweet and sour, loved every bite.', 9, 27, 37), -- Gummy Bears
('Ali Aliev', 'Rich and creamy, melts in your mouth.', 8, 28, 38), -- Vanilla Ice Cream
('Ai Mukhamedzhanov', 'Crunchy and satisfying, great for snacking.', 8, 29, 39), -- Almond Brittle
('Elvira Kasymova', 'Fresh and flavorful, loved the variety of flavors.', 9, 30, 40); -- Assorted Chocolates

-- Добавление отзывов для фруктов
INSERT INTO Reviews (Name, Content, Grade, UserId, ProductId)
VALUES 
('Denis Semenov', 'Sweet and juicy, loved every bite.', 9, 26, 41), -- Apple
('Ai Zadatimirova', 'Refreshing and flavorful, perfect for summer.', 9, 27, 42), -- Watermelon
('Ali Aliev', 'Delicious and nutritious, great for a quick snack.', 8, 28, 43), -- Banana
('Ai Mukhamedzhanov', 'Tangy and aromatic, excellent quality.', 8, 29, 44), -- Orange
('Elvira Kasymova', 'Perfectly ripe, enjoyed every slice.', 9, 30, 45); -- Mango
