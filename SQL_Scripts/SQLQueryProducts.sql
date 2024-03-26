USE WebStoreDB;

INSERT INTO MainCategory (Name) VALUES
('Electronics'),
('Clothing'),
('Products');

-- Electronics
INSERT INTO SubCategory (Name, ImageURL, IconURL, MainCategoryId) VALUES
('Smartphones', 'smartphones.jpg', 'smartphones_icon.jpg', 1),
('Laptops', 'laptops.jpg', 'laptops_icon.jpg', 1),
('Tablets', 'tablets.jpg', 'tablets_icon.jpg', 1);

-- Clothing
INSERT INTO SubCategory (Name, ImageURL, IconURL, MainCategoryId) VALUES
('Shirts', 'shirts.jpg', 'shirts_icon.jpg', 2),
('Jeans', 'jeans.jpg', 'jeans_icon.jpg', 2),
('Dresses', 'dresses.jpg', 'dresses_icon.jpg', 2);

-- Products
INSERT INTO SubCategory (Name, ImageURL, IconURL, MainCategoryId) VALUES
('Meat', 'meat.jpg', 'meat_icon.jpg', 3),
('Sweets', 'sweets.jpg', 'sweets_icon.jpg', 3),
('Fruits', 'fruits.jpg', 'fruits_icon.jpg', 3);

-- Smartphones
INSERT INTO Product (Name, ImageURL, SubCategoryId, Description, Price, Grade, FreqPurchases)
VALUES
('iPhone 13', 'iphone15.jpg', 1, 'Latest smartphone from Apple', 999.99, 0, 0),
('Samsung Galaxy S22', 'galaxys22.jpg', 1, 'Flagship Android smartphone', 899.99, 0, 0),
('Google Pixel 6', 'pixel6.jpg', 1, 'Google''s latest smartphone with impressive camera', 799.99, 0, 0),
('OnePlus 9 Pro', 'oneplus9pro.jpg', 1, 'Powerful Android device with OxygenOS', 899.99, 0, 0),
('Xiaomi Mi 11', 'mi12.jpg', 1, 'Affordable flagship smartphone from Xiaomi', 699.99, 0, 0),
('Sony Xperia 1 III', 'xperia1iii.jpg', 1, 'Sony''s flagship smartphone with 4K display', 1099.99, 0, 0),
('Huawei P50 Pro', 'p50pro.jpg', 1, 'Premium smartphone with Leica cameras', 899.99, 0, 0),
('ASUS ROG Phone 5', 'rogphone5.jpg', 1, 'Gaming smartphone with high-refresh-rate display', 999.99, 0, 0),
('LG Wing', 'lgwing.jpg', 1, 'Unique dual-screen smartphone from LG', 799.99, 0, 0),
('Motorola Edge 20 Pro', 'edge20pro.jpg', 1, 'Motorola''s flagship with Snapdragon 870', 699.99, 0, 0),
('Nokia X100', 'nokiax100.jpg', 1, 'Budget-friendly 5G smartphone from Nokia', 399.99, 0, 0),
('Realme GT 2 Pro', 'gt2pro.jpg', 1, 'Feature-packed smartphone at an affordable price', 599.99, 0, 0),
('Oppo Find X5 Pro', 'findx5pro.jpg', 1, 'Elegant smartphone with Hasselblad camera partnership', 899.99, 0, 0),
('ZTE Axon 30 Ultra', 'axon30ultra.jpg', 1, '5G flagship with advanced camera capabilities', 799.99, 0, 0);

-- Laptops
INSERT INTO Product (Name, ImageURL, SubCategoryId, Description, Price, Grade, FreqPurchases)
VALUES
('MacBook Pro 2022', 'macbookpro2022.jpg', 2, 'Powerful laptop from Apple', 1999.99, 0, 0),
('Dell XPS 15', 'dellxps15.jpg', 2, 'High-performance Windows laptop', 1499.99, 0, 0),
('HP Spectre x360', 'spectrex360.jpg', 2, 'Convertible laptop with premium design', 1299.99, 0, 0),
('Lenovo ThinkPad X1 Carbon', 'thinkpadx1.jpg', 2, 'Business ultrabook with robust build quality', 1399.99, 0, 0),
('Microsoft Surface Laptop 4', 'surfacelaptop4.jpg', 2, 'Slim and stylish laptop with excellent display', 1299.99, 0, 0),
('Razer Blade 15', 'blade15.jpg', 2, 'Gaming laptop with RTX graphics and high refresh rate', 1799.99, 0, 0),
('ASUS ZenBook Duo', 'zenbookduo.jpg', 2, 'Dual-screen laptop for enhanced productivity', 1499.99, 0, 0),
('Acer Swift 5', 'swift5.jpg', 2, 'Lightweight ultrabook with long battery life', 999.99, 0, 0),
('MSI Prestige 14', 'prestige14.jpg', 2, 'Creator laptop with powerful specifications', 1599.99, 0, 0),
('LG Gram 17', 'lggram17.jpg', 2, 'Ultra-light laptop with large display and long battery life', 1499.99, 0, 0),
('Huawei MateBook X Pro', 'matebookxpro.jpg', 2, 'Slim and powerful laptop with 3K touchscreen', 1599.99, 0, 0),
('Samsung Galaxy Book Pro', 'galaxybookpro.jpg', 2, 'Thin and light laptop with AMOLED display', 1299.99, 0, 0),
('Xiaomi Mi Notebook Pro', 'minotebookpro.jpg', 2, 'Affordable laptop with premium design and specs', 1099.99, 0, 0);

-- Tablets
INSERT INTO Product (Name, ImageURL, SubCategoryId, Description, Price, Grade, FreqPurchases)
VALUES
('iPad Air', 'ipadair.jpg', 3, 'Versatile tablet from Apple', 599.99, 0, 0),
('Samsung Galaxy Tab S8', 'galaxytabs8.jpg', 3, 'Android tablet with AMOLED display', 649.99, 0, 0),
('Microsoft Surface Pro 8', 'surfacepro8.jpg', 3, 'Powerful Windows tablet with detachable keyboard', 899.99, 0, 0),
('Lenovo Tab P11 Pro', 'tabp11pro.jpg', 3, 'Premium Android tablet with OLED display', 599.99, 0, 0),
('Amazon Fire HD 10', 'firehd10.jpg', 3, 'Budget-friendly tablet with Alexa integration', 149.99, 0, 0),
('Huawei MatePad Pro', 'matepadpro.jpg', 3, 'Android tablet with stylus support and high-resolution display', 699.99, 0, 0),
('Xiaomi Pad 5', 'xiaomipad5.jpg', 3, 'Affordable Android tablet with Snapdragon processor', 399.99, 0, 0),
('ASUS ZenPad 3S 10', 'zenpad3s10.jpg', 3, 'Thin and light Android tablet with premium build', 299.99, 0, 0),
('Google Pixel Slate', 'pixelslate.jpg', 3, 'Google''s Chrome OS tablet with detachable keyboard', 699.99, 0, 0),
('Lenovo Yoga Tab 13', 'yogatab13.jpg', 3, 'Versatile Android tablet with built-in kickstand', 599.99, 0, 0),
('Sony Xperia Tablet Z4', 'xperiatabletz4.jpg', 3, 'Waterproof Android tablet with 2K display', 799.99, 0, 0),
('LG G Pad 5 10.1', 'lggpad5.jpg', 3, 'Mid-range Android tablet with long battery life', 349.99, 0, 0),
('Nokia T20', 'nokiat20.jpg', 3, 'Budget-friendly Android tablet with large display', 199.99, 0, 0);



-- Shirts
INSERT INTO Product (Name, ImageURL, SubCategoryId, Description, Price, Grade, FreqPurchases)
VALUES
('Crew Neck T-Shirt', 'crewneck.jpg', 4, 'Basic cotton t-shirt for everyday wear', 19.99, 0, 0),
('V-Neck T-Shirt', 'vneck.jpg', 4, 'Classic v-neck t-shirt in various colors', 24.99, 0, 0),
('Polo Shirt', 'polo.jpg', 4, 'Collared polo shirt for a smart-casual look', 29.99, 0, 0),
('Button-Down Shirt', 'buttondown.jpg', 4, 'Formal button-down shirt made of wrinkle-resistant fabric', 39.99, 0, 0),
('Flannel Shirt', 'flannel.jpg', 4, 'Cozy flannel shirt for cooler weather', 34.99, 0, 0),
('Oxford Shirt', 'oxford.jpg', 4, 'Classic oxford shirt suitable for various occasions', 44.99, 0, 0),
('Denim Shirt', 'denim.jpg', 4, 'Stylish denim shirt for a rugged look', 49.99, 0, 0),
('Hawaiian Shirt', 'hawaiian.jpg', 4, 'Colorful Hawaiian shirt perfect for summer vibes', 29.99, 0, 0),
('Henley Shirt', 'henley.jpg', 4, 'Casual henley shirt with buttoned placket', 27.99, 0, 0),
('Graphic T-Shirt', 'graphic.jpg', 4, 'T-shirt featuring a unique graphic print', 21.99, 0, 0),
('Long Sleeve Shirt', 'longsleeve.jpg', 4, 'Comfortable long sleeve shirt for layering', 29.99, 0, 0),
('Sport Shirt', 'sportshirt.jpg', 4, 'Moisture-wicking sport shirt for active wear', 34.99, 0, 0),
('Silk Shirt', 'silk.jpg', 4, 'Luxurious silk shirt for special occasions', 79.99, 0, 0),
('Rugby Shirt', 'rugby.jpg', 4, 'Striped rugby shirt for a preppy look', 39.99, 0, 0);

-- Jeans
INSERT INTO Product (Name, ImageURL, SubCategoryId, Description, Price, Grade, FreqPurchases)
VALUES
('Skinny Jeans', 'skinny.jpg', 5, 'Tight-fitting skinny jeans for a modern silhouette', 59.99, 0, 0),
('Slim Fit Jeans', 'slimfit.jpg', 5, 'Tailored slim fit jeans for a sleek look', 54.99, 0, 0),
('Straight Leg Jeans', 'straightleg.jpg', 5, 'Classic straight leg jeans in various washes', 49.99, 0, 0),
('Bootcut Jeans', 'bootcut.jpg', 5, 'Flared bootcut jeans for a retro vibe', 64.99, 0, 0),
('Relaxed Fit Jeans', 'relaxedfit.jpg', 5, 'Loose-fitting relaxed fit jeans for comfort', 44.99, 0, 0),
('High Waisted Jeans', 'highwaisted.jpg', 5, 'Fashionable high waisted jeans for a trendy look', 69.99, 0, 0),
('Wide Leg Jeans', 'wideleg.jpg', 5, 'Fashion-forward wide leg jeans with a vintage feel', 79.99, 0, 0),
('Cropped Jeans', 'cropped.jpg', 5, 'Stylish cropped jeans for a chic vibe', 49.99, 0, 0),
('Distressed Jeans', 'distressed.jpg', 5, 'Edgy distressed jeans with ripped details', 59.99, 0, 0),
('Raw Denim Jeans', 'rawdenim.jpg', 5, 'Authentic raw denim jeans for denim enthusiasts', 89.99, 0, 0),
('Cuffed Jeans', 'cuffed.jpg', 5, 'Casually cuffed jeans for a laid-back look', 54.99, 0, 0),
('Cargo Jeans', 'cargo.jpg', 5, 'Functional cargo jeans with multiple pockets', 69.99, 0, 0),
('Stretch Jeans', 'stretch.jpg', 5, 'Comfortable stretch jeans for ease of movement', 54.99, 0, 0),
('Low Rise Jeans', 'lowrise.jpg', 5, 'Low rise jeans for a youthful aesthetic', 49.99, 0, 0);

-- Dresses
INSERT INTO Product (Name, ImageURL, SubCategoryId, Description, Price, Grade, FreqPurchases)
VALUES
('Little Black Dress', 'littleblack.jpg', 6, 'Timeless little black dress for any occasion', 79.99, 0, 0),
('Maxi Dress', 'maxi.jpg', 6, 'Flowy maxi dress perfect for summer days', 69.99, 0, 0),
('Wrap Dress', 'wrap.jpg', 6, 'Versatile wrap dress that flatters any figure', 59.99, 0, 0),
('Shift Dress', 'shift.jpg', 6, 'Classic shift dress suitable for work or play', 49.99, 0, 0),
('Midi Dress', 'midi.jpg', 6, 'Chic midi dress for a sophisticated look', 64.99, 0, 0),
('Bodycon Dress', 'bodycon.jpg', 6, 'Form-fitting bodycon dress for a sexy silhouette', 54.99, 0, 0),
('Sundress', 'sundress.jpg', 6, 'Light and airy sundress for sunny days', 39.99, 0, 0),
('Slip Dress', 'slip.jpg', 6, 'Sleek slip dress perfect for layering', 49.99, 0, 0),
('Sheath Dress', 'sheath.jpg', 6, 'Elegant sheath dress for a polished look', 59.99, 0, 0),
('Pencil Dress', 'pencil.jpg', 6, 'Sophisticated pencil dress for office attire', 69.99, 0, 0),
('Fit and Flare Dress', 'fitandflare.jpg', 6, 'Flattering fit and flare dress for a feminine silhouette', 59.99, 0, 0),
('Bodycon Dress', 'bodycon2.jpg', 6, 'Figure-hugging bodycon dress for a night out', 44.99, 0, 0),
('Off Shoulder Dress', 'offshoulder.jpg', 6, 'Trendy off shoulder dress for a romantic vibe', 49.99, 0, 0),
('Halter Dress', 'halter.jpg', 6, 'Chic halter neck dress for a glamorous look', 54.99, 0, 0);



-- Meat
INSERT INTO Product (Name, ImageURL, SubCategoryId, Description, Price, Grade, FreqPurchases)
VALUES
('Beef Tenderloin', 'beef.jpg', 7, 'Premium cut of beef known for its tenderness', 19.99, 0, 0),
('Chicken Breast', 'chicken.jpg', 7, 'Boneless, skinless chicken breast for various recipes', 9.99, 0, 0),
('Salmon Fillet', 'salmon.jpg', 7, 'Fresh salmon fillet rich in omega-3 fatty acids', 14.99, 0, 0),
('Pork Chop', 'pork.jpg', 7, 'Juicy pork chop perfect for grilling or pan-frying', 12.99, 0, 0),
('Lamb Rack', 'lamb.jpg', 7, 'Delicious lamb rack suitable for roasting', 24.99, 0, 0),
('Ground Beef', 'groundbeef.jpg', 7, 'Versatile ground beef for burgers, meatballs, and more', 7.99, 0, 0),
('Ribeye Steak', 'ribeye.jpg', 7, 'Flavorful ribeye steak with marbled texture', 16.99, 0, 0),
('Turkey Breast', 'turkey.jpg', 7, 'Lean turkey breast ideal for sandwiches and salads', 11.99, 0, 0),
('Duck Breast', 'duck.jpg', 7, 'Tender duck breast with rich flavor', 18.99, 0, 0),
('Veal Chop', 'veal.jpg', 7, 'Tender veal chop perfect for grilling or sautéing', 22.99, 0, 0),
('Sausages', 'sausages.jpg', 7, 'Assorted sausages for breakfast or grilling', 8.99, 0, 0),
('Bacon', 'bacon.jpg', 7, 'Smoked bacon strips for breakfast or cooking', 6.99, 0, 0),
('Lobster Tail', 'lobster.jpg', 7, 'Indulgent lobster tail for special occasions', 29.99, 0, 0),
('Shrimp', 'shrimp.jpg', 7, 'Fresh shrimp for various seafood dishes', 17.99, 0, 0);

-- Sweets
INSERT INTO Product (Name, ImageURL, SubCategoryId, Description, Price, Grade, FreqPurchases)
VALUES
('Chocolate Cake', 'chocolatecake.jpg', 8, 'Decadent chocolate cake for dessert lovers', 29.99, 0, 0),
('Vanilla Cupcakes', 'vanillacupcakes.jpg', 8, 'Delicious vanilla cupcakes with creamy frosting', 19.99, 0, 0),
('Strawberry Cheesecake', 'strawberrycheesecake.jpg', 8, 'Creamy cheesecake topped with fresh strawberries', 34.99, 0, 0),
('Apple Pie', 'applepie.jpg', 8, 'Classic apple pie with flaky crust and cinnamon-spiced filling', 24.99, 0, 0),
('Brownies', 'brownies.jpg', 8, 'Rich and fudgy chocolate brownies for a decadent treat', 14.99, 0, 0),
('Cookies', 'cookies.jpg', 8, 'Assorted cookies including chocolate chip, oatmeal, and more', 9.99, 0, 0),
('Ice Cream', 'icecream.jpg', 8, 'Various flavors of creamy ice cream for dessert time', 6.99, 0, 0),
('Donuts', 'donuts.jpg', 8, 'Freshly baked donuts in assorted flavors', 1.99, 0, 0),
('Cupcakes', 'cupcakes.jpg', 8, 'Colorful cupcakes with buttercream frosting', 2.99, 0, 0),
('Caramel Popcorn', 'popcorn.jpg', 8, 'Sweet and crunchy caramel-coated popcorn', 4.99, 0, 0),
('Fruit Tart', 'fruittart.jpg', 8, 'Delicate fruit tart with pastry cream and fresh fruit topping', 29.99, 0, 0),
('Chocolate Truffles', 'truffles.jpg', 8, 'Luxurious chocolate truffles dusted with cocoa powder', 19.99, 0, 0),
('Pecan Pie', 'pecanpie.jpg', 8, 'Rich and nutty pecan pie with flaky crust', 27.99, 0, 0),
('Gelato', 'gelato.jpg', 8, 'Italian-style gelato in assorted flavors', 7.99, 0, 0);

-- Fruits
INSERT INTO Product (Name, ImageURL, SubCategoryId, Description, Price, Grade, FreqPurchases)
VALUES
('Apple', 'apple.jpg', 9, 'Crisp and juicy apple perfect for snacking', 0.99, 0, 0),
('Banana', 'banana.jpg', 9, 'Naturally sweet banana rich in potassium', 0.49, 0, 0),
('Orange', 'orange.jpg', 9, 'Refreshing and tangy orange packed with vitamin C', 0.79, 0, 0),
('Strawberry', 'strawberry.jpg', 9, 'Sweet and juicy strawberry bursting with flavor', 1.29, 0, 0),
('Grapes', 'grapes.jpg', 9, 'Plump and sweet grapes ideal for a healthy snack', 2.99, 0, 0),
('Watermelon', 'watermelon.jpg', 9, 'Refreshing and hydrating watermelon slices', 3.99, 0, 0),
('Pineapple', 'pineapple.jpg', 9, 'Tropical pineapple with sweet and tangy flavor', 2.49, 0, 0),
('Mango', 'mango.jpg', 9, 'Exotic mango with creamy texture and sweet taste', 1.99, 0, 0),
('Kiwi', 'kiwi.jpg', 9, 'Tart and tangy kiwi packed with vitamins', 1.49, 0, 0),
('Blueberries', 'blueberries.jpg', 9, 'Tiny and flavorful blueberries loaded with antioxidants', 4.99, 0, 0),
('Peach', 'peach.jpg', 9, 'Juicy and fragrant peach perfect for desserts and snacks', 1.79, 0, 0),
('Plum', 'plum.jpg', 9, 'Sweet and juicy plum with smooth skin', 1.29, 0, 0),
('Cherry', 'cherry.jpg', 9, 'Plump and sweet cherries for snacking or baking', 3.49, 0, 0),
('Pomegranate', 'pomegranate.jpg', 9, 'Nutrient-rich pomegranate seeds packed with antioxidants', 2.99, 0, 0);