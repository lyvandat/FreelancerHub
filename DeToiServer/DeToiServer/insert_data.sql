-- DELETE ALL!!!
Delete from [OrderServiceTypes];
Delete from [OrderService];
Delete from [OrderSkillsRequired];
Delete from [Orders];
Delete from [Services];

DELETE from [FreelancePaymentHistories];
DELETE from [FreelanceServiceTypes];
Delete from [SkillServiceTypes];
Delete from [FreelanceSkills];
Delete from [Skills];

DELETE from FreelanceCorrectQuestions;
delete from QuizQuestions;
delete from FreelanceQuizAnswers;
delete from FreelanceQuizQuestions;
delete from FreelanceQuizzes;
DELETE from FreelanceQuizResults;

Delete from [Addresses];
Delete from [Freelancers];
Delete from [Customers];
Delete from [Accounts];

Delete from [UIElementAdditionServiceRequirements];
Delete from [UIElementServiceRequirements];
Delete from [UIElementValidationTypes];
Delete from [UIElementServiceRequirementInputMethods];
Delete from [UIElementInputOptions];
Delete from [UIElementInputMethodTypes];

DELETE FROM [ServiceTypes];
DELETE FROM [ServiceCategories];

INSERT INTO [ServiceCategories] ([Id], [Name], [Image], [Description], [ServiceClassName]) VALUES
('1b1a6ebd-2838-4b3d-a1f1-1818305df2d6', N'Vận Chuyển', 'https://detoivn.b-cdn.net/services/chuyennhaphongtro/category.png', N'Dịch vụ Vận Chuyển giúp bạn chuyển đồ đạc, hàng hóa từ một địa điểm này đến địa điểm khác một cách thuận tiện và nhanh chóng', 'Moving'),
('8a21b21e-dc31-49c8-8b5b-84b69204dc3a', N'Sửa chữa', 'https://detoivn.b-cdn.net/services/suachua/category.png', N'Dịch vụ Sửa chữa cung cấp các dịch vụ sửa chữa và bảo dưỡng cho các thiết bị, sản phẩm, hoặc cơ sở hạ tầng của bạn.', 'Reparing'),
('d17ad87c-9f80-4f0e-bfd4-53138d900a6e', N'Dọn dẹp', 'https://detoivn.b-cdn.net/services/dondep/category.png', N'Dịch vụ Dọn dẹp giúp bạn làm sạch và sắp xếp không gian sống hoặc làm việc của mình để tạo ra một môi trường sạch sẽ và thoải mái.', 'Cleaning'),
('6f57d993-eb26-4b35-8c7d-7871a7fd624f', N'Đời sống', 'https://detoivn.b-cdn.net/services/dicho/category.png', N'Dịch vụ Đời sống cung cấp các dịch vụ hỗ trợ các vấn đề trong cuộc sống hàng ngày của bạn như chăm sóc người già, trẻ em, đi chợ, nấu ăn, giặt ủi, mua sắm tại siêu thị, v.v.', 'Life'); 

INSERT INTO [ServiceTypes] ([Id], [Name], [BasePrice], [Description], [Image]) VALUES
('7986a30b-5b5e-4d9d-9446-1d554d11055f', N'Vận chuyển hàng hóa', 0, N'Dịch vụ Vận chuyển hàng hóa cung cấp các dịch vụ vận chuyển cho hàng hóa lớn, đóng gói chắc chắn và an toàn từ điểm này đến điểm khác.', null),
('530d29ca-17a1-4db9-a569-09a17e30b0af', N'Giao hàng nhanh', 0, N'Dịch vụ Giao hàng nhanh cung cấp dịch vụ giao hàng cho các đơn hàng nhỏ và cần được giao đi trong thời gian ngắn.', null),
('9f6bf976-ec5d-4e31-bfeb-7aea7637f20e', N'Chăm sóc người già, trẻ em', 0, N'Dịch vụ Chăm sóc người già, trẻ em cung cấp các dịch vụ chăm sóc và giám sát cho người già và trẻ em trong gia đình của bạn.', null),
('b1c2cd51-bbe5-4b95-bcf4-3f04b57357d0', N'Mua sắm tại siêu thị', 0, N'Dịch vụ Mua sắm tại siêu thị cung cấp dịch vụ mua sắm tại các siêu thị hoặc cửa hàng để bạn không phải mất thời gian và công sức.', null),
('8a4ad0e1-16fd-457e-a6f0-16accaf8e764', N'Vận chuyển đồ đạc', 0, N'Dịch vụ Vận chuyển đồ đạc cung cấp dịch vụ chuyển phát nhanh cho các đồ đạc như hành lý cá nhân, đồ dùng gia đình, và các vật phẩm cá nhân khác.', null),
('f146cba9-72a1-47be-a36d-9bf6407f59d9', N'Đi chợ', 0, N'Dịch vụ Đi chợ cung cấp dịch vụ mua sắm tại các cửa hàng, siêu thị hoặc chợ truyền thống để thuận tiện cho bạn.', null),
('531f4e94-1880-4d31-b001-6f59ff0322f0', N'Nấu ăn', 0, N'Dịch vụ Nấu ăn cung cấp dịch vụ chuẩn bị và nấu các bữa ăn ngon miệng và dinh dưỡng cho gia đình hoặc sự kiện của bạn.', null),
('dc3262c0-6cf9-4058-be3c-98e4bb401ada', N'Giặt ủi', 0, N'Dịch vụ Giặt ủi cung cấp dịch vụ giặt và ủi quần áo và vật dụng gia đình để bạn có thời gian và năng lượng cho những việc khác.', null),
('80998115-c96e-43f8-80b9-2c37272be33f', N'Sửa chữa máy lạnh', 0, N'Dịch vụ Sửa chữa máy lạnh cung cấp các dịch vụ sửa chữa, bảo dưỡng và lắp đặt cho máy lạnh tại nhà hoặc cơ sở của bạn.', null),
('509827e5-0852-4ea2-9fa4-7551bbbf88d9', N'Sửa chữa ống nước', 0, N'Dịch vụ Sửa chữa ống nước cung cấp các dịch vụ sửa chữa và bảo dưỡng cho hệ thống ống nước của bạn, bao gồm việc sửa chữa các rò rỉ và thay thế ống hỏng.', null),
('9fb42b78-0266-4222-a923-11d1d54ec673', N'Sửa chữa sàn nhà', 0, N'Dịch vụ Sửa chữa sàn nhà cung cấp các dịch vụ sửa chữa, làm mới và bảo dưỡng cho các loại sàn nhà như gạch, đá, gỗ, hoặc sàn nhựa tại nhà của bạn.', null),
('3b8a2d6a-b0e7-46af-a688-397cea642603', N'Dọn dẹp nhà cửa', 0, N'Dịch vụ Dọn dẹp nhà cửa cung cấp các dịch vụ dọn dẹp và lau chùi cho các căn nhà, bao gồm cả việc lau dọn, bố trí lại nội thất, và lau sạch các bề mặt.', null),
('fc1a6664-748c-4aa3-b7be-82300f8fdd0c', N'Tổng vệ sinh', 0, N'Dịch vụ Tổng vệ sinh cung cấp các dịch vụ vệ sinh sâu và triệt để cho căn nhà của bạn, bao gồm cả việc lau chùi, vệ sinh định kỳ và sơn phủ bề mặt cần thiết.', null),
('ad460783-3b95-4057-a735-d73b491c2bd8', N'Dọn dẹp văn phòng', 0, N'Dịch vụ Dọn dẹp văn phòng cung cấp các dịch vụ dọn dẹp và lau chùi cho không gian văn phòng, giúp tạo môi trường làm việc sạch sẽ và thoải mái.', null),
('79e7bb6a-4c26-4444-b7b2-4e95060bc3b6', N'Vệ sinh cửa sổ', 0, N'Dịch vụ Vệ sinh cửa sổ cung cấp dịch vụ làm sạch cửa sổ, bao gồm cả việc lau kính và lau chùi khung cửa, để đảm bảo sự sáng bóng và thoáng đãng cho căn nhà hoặc văn phòng của bạn.', null),
('4a6fc79c-35bf-45cc-99c3-9bb0707a2883', N'Vệ sinh thảm văn phòng', 0, N'Dịch vụ Vệ sinh thảm văn phòng cung cấp dịch vụ làm sạch và vệ sinh cho các loại thảm trải sàn trong văn phòng, giúp loại bỏ bụi bẩn và vi khuẩn, đồng thời tạo môi trường làm việc sạch sẽ và an toàn.', null),
('036b78bd-630e-4553-ae22-81a938c96112', N'Vệ sinh máy lạnh', 0, N'Dịch vụ Vệ sinh máy lạnh cung cấp dịch vụ làm sạch và bảo dưỡng cho hệ thống máy lạnh của bạn, giúp tăng tuổi thọ và hiệu suất làm việc của máy lạnh, đồng thời cải thiện chất lượng không khí trong không gian sống hoặc làm việc.', null); 

INSERT INTO [Accounts] ([Id], [Email], [FullName], [DateOfBirth], [Phone], [Role], [Avatar], [RefreshToken], [LoginToken], [LoginTokenExpires], [TokenCreated], [TokenExpires], [IsActive], [IsVerified]) VALUES
('39aca440-876b-4503-8cb9-1d34ce9b9169', null, N'Ngô Vũ Lan Ngọc', '2006-02-11', '+84337839146', 'Freelancer', 'https://detoivn.b-cdn.net/customer_avt/user-avt%20(3).png', 'string', 'default', '2024-04-07T17:25:40.772804', '2024-04-07 17:15:40.772804', '2024-04-07 17:25:40.772804', 1, 1),
('8f38f967-6ae8-4b30-81af-d717ac6724e8', null, N'Vũ Ngô Thục Oanh', '2006-03-12', '+84914510313', 'Freelancer', 'https://detoivn.b-cdn.net/customer_avt/user-avt%20(2).png', 'string', 'default', '2024-04-07T17:25:40.778922', '2024-04-07 17:15:40.778922', '2024-04-07 17:25:40.778922', 1, 1),
('85f68b8c-d452-41b6-9b7f-6e2959c7b501', null, N'Trương Dương Minh Ân', '1978-01-01', '+84373344545', 'Customer', 'https://detoivn.b-cdn.net/customer_avt/user-avt%20(3).png', 'string', 'default', '2024-04-07T17:25:40.825617', '2024-04-07 17:15:40.825617', '2024-04-07 17:25:40.825617', 1, 1); 

INSERT INTO [Freelancers] ([Id], [AccountId], [Rating], [TotalReviewCount], [Balance], [SystemBalance], [OrderCount], [LoveCount], [PositiveReviewCount], [IdentityNumber], [IsTeam], [Description], [TeamMemberCount]) VALUES
('aa1f6884-b260-4011-a3b8-99aa05fc2258', '39aca440-876b-4503-8cb9-1d34ce9b9169', 0, 0, 'xUazd0pcmUhB9P7xAesHSA==', 'YKdQMV7VLWp2eBabmES4OA==', 0, 0, 0, '051200000011', 0, 'Total financial role together range line beyond its. Policy daughter need kind miss artist truth trouble. Rest human station property. Partner stock four. Region as true develop sound central. Language ball floor meet usually board necessary.', 1),
('9378f86c-81c0-4e68-b10e-47f69ffb7580', '8f38f967-6ae8-4b30-81af-d717ac6724e8', 0, 0, '2ruExrZ016VYD28zMC/Jkw==', 'vHaikREebtBYJMNJWD1h8Q==', 0, 0, 0, '051200000012', 0, 'Offer face country cost party prevent. Attorney quickly candidate change although bag record. Raise study modern miss dog Democrat quickly. Often late produce you true soldier. Food break onto friend.', 1); 

INSERT INTO [Customers] ([Id], [AccountId], [CustomerRank], [MemberPoint]) VALUES
('b571706b-a3af-4dde-bb0d-25b5e0295500', '85f68b8c-d452-41b6-9b7f-6e2959c7b501', 'Unranked', 0); 

INSERT INTO [Addresses] ([Id], [Lat], [Lon], [CustomerAccountId], [FreelanceAccountId], [AddressLine], [Ward], [District], [Province], [Country]) VALUES
('0a1f69ef-62de-4238-ac99-5e38b4a11b2b', 10.50265700452294, 106.98440747582454, null, 'aa1f6884-b260-4011-a3b8-99aa05fc2258', N'227 Nguyễn Văn Cừ, phường 4, Quận 5, Thành phố Hồ Chí Minh, Việt Nam', N'Phường Tân Kiểng', N'Quận 7', N'Thành phố Hồ Chí Minh', N'Việt Nam'),
('8562bfc3-a97f-4b43-98f0-551f3be6030b', 10.69965888536901, 106.76448958678068, null, '9378f86c-81c0-4e68-b10e-47f69ffb7580', N'227 Nguyễn Văn Cừ, phường 4, Quận 5, Thành phố Hồ Chí Minh, Việt Nam', N'Phường Tăng Nhơn Phú A', N'Quận 9', N'Thành phố Hồ Chí Minh', N'Việt Nam'),
('0a3ef50a-d6d5-4957-86b4-469ca9089e2f', 10.614720283259071, 106.67879608212947, 'b571706b-a3af-4dde-bb0d-25b5e0295500', null, N'227 Nguyễn Văn Cừ, phường 4, Quận 5, Thành phố Hồ Chí Minh, Việt Nam', N'Phường 8', N'Quận Phú Nhuận', N'Thành phố Hồ Chí Minh', N'Việt Nam'); 

INSERT INTO [Skills] ([Id], [Name], [Description]) VALUES
('d4c95511-492f-46aa-8326-84299acbe8fd', N'Vận chuyển hàng hóa', N'Xếp dỡ hàng hóa một cách an toàn và chuyên nghiệp'),
('510acfa4-eddb-4d08-b4ce-30ebf132922f', N'Quản lý lộ trình vận chuyển', N'Lập kế hoạch và điều chỉnh lộ trình vận chuyển hiệu quả'),
('28c41f96-ad80-457f-b59b-e948d1bd9135', N'Xử lý hàng hóa nhạy cảm', N'Chăm sóc và vận chuyển hàng hóa nhạy cảm một cách cẩn thận và đúng cách'),
('92fd24e8-abeb-45d3-a33c-02d24224b78d', N'Sử dụng các phương tiện vận chuyển đa dạng', N'Sử dụng xe tải, container và các phương tiện vận tải khác để vận chuyển hàng hóa một cách linh hoạt'),
('e7978b8d-a546-4133-a576-778f34985d06', N'Đóng gói hàng hóa chuyên nghiệp', N'Đóng gói hàng hóa bằng cách an toàn và chuyên nghiệp để đảm bảo an toàn trong quá trình vận chuyển'),
('d9b6ce05-94a3-4781-976d-707579d6fe5f', N'Giao hàng nhanh', N'Giao hàng nhanh chóng và chính xác đến địa chỉ chỉ định'),
('657fabfe-88db-46b4-ba2c-947f36b0ea45', N'Quản lý lịch trình giao hàng', N'Quản lý lịch trình giao hàng để đảm bảo giao hàng đúng thời hạn'),
('db42a4fc-a790-4706-bd0b-c263dbbc2522', N'Sử dụng phương tiện giao hàng nhỏ', N'Sử dụng xe máy, xe đạp hoặc phương tiện giao hàng nhỏ khác để giao hàng một cách nhanh chóng và linh hoạt'),
('562bb844-3fe4-486c-94a6-28876cdb287d', N'Xử lý hàng hóa đặc biệt', N'Xử lý và vận chuyển hàng hóa đặc biệt một cách chuyên nghiệp và cẩn thận'),
('126d9bee-996a-4880-b54e-a2ee84b5e822', N'Giao hàng theo yêu cầu', N'Giao hàng dựa trên yêu cầu cụ thể của khách hàng'),
('44c2a6e0-9437-4bee-b150-ffe0dc1b1c37', N'Chăm sóc người già', N'Cung cấp chăm sóc toàn diện cho người già trong gia đình'),
('049657d4-138c-4d0b-8d56-245e7f0a841d', N'Chăm sóc trẻ em', N'Đảm bảo sự an toàn và sự phát triển của trẻ em trong môi trường gia đình'),
('a9b4b60a-999d-463e-9d75-5ba249c3c91f', N'Xây dựng mối quan hệ với trẻ em', N'Xây dựng mối quan hệ tốt đẹp và trách nhiệm với trẻ em để tạo ra một môi trường hòa thuận và an toàn'),
('8837d38a-d219-40f5-9bc7-b439e69d17d2', N'Giáo dục về dinh dưỡng', N'Cung cấp kiến thức và hướng dẫn về dinh dưỡng cho trẻ em để hỗ trợ sự phát triển của họ'),
('b6f8ae11-db74-4c55-a9d7-f8904d4d5825', N'Tạo ra hoạt động giáo dục', N'Phát triển và tổ chức các hoạt động giáo dục thú vị và phù hợp với lứa tuổi của trẻ em'),
('59a05b2f-2857-49e0-a5dc-7e1746480dce', N'Lập danh sách mua sắm', N'Tạo danh sách mua sắm chi tiết và hiệu quả để tiết kiệm thời gian và tiền bạc'),
('e9d1a4d9-053f-4a60-a67e-3d59a11feeeb', N'Tư vấn lựa chọn sản phẩm', N'Tư vấn và hướng dẫn khách hàng trong việc lựa chọn sản phẩm phù hợp với nhu cầu và ngân sách của họ'),
('3eda0312-2f58-4f02-852d-bec6e4bc344b', N'Quản lý ngân sách mua sắm', N'Quản lý ngân sách mua sắm của khách hàng để đảm bảo mua sắm hiệu quả và không lãng phí'),
('d2fa3f68-6d70-4707-adda-0268312c25ee', N'Xử lý việc đổi trả hàng', N'Hỗ trợ khách hàng trong việc đổi trả hàng hoặc xử lý các vấn đề liên quan đến sản phẩm sau khi mua'),
('34698e8c-7ba7-4f52-851b-e2bf6c10426b', N'Kiểm tra sản phẩm', N'Kiểm tra sản phẩm để đảm bảo chất lượng và đầy đủ các thành phần trước khi mua'),
('7a5066e5-c755-4f49-9afa-0813626afb04', N'Xếp dỡ đồ đạc một cách chuyên nghiệp', N'Thực hiện việc xếp dỡ các đồ đạc như hành lý cá nhân và đồ dùng gia đình một cách chuyên nghiệp và an toàn'),
('fc77b33f-5f6e-4495-9837-14d8a049882d', N'Đóng gói hàng hóa cá nhân', N'Thực hiện việc đóng gói hàng hóa cá nhân như hành lý cá nhân và các vật phẩm cá nhân một cách cẩn thận và chuyên nghiệp'),
('8953f6d9-1e51-4907-b8ee-44cb5b4787d0', N'Quản lý kho hàng', N'Thực hiện việc quản lý và tổ chức kho hàng cho đồ đạc cá nhân một cách hiệu quả và chuyên nghiệp'),
('43bcbdaf-3cd6-44e4-add3-aec51dcf2c7d', N'Đóng gói và vận chuyển hàng hóa quốc tế', N'Thực hiện việc đóng gói và vận chuyển hàng hóa cá nhân qua các biên giới quốc tế một cách chuyên nghiệp và an toàn'),
('919b1e17-6392-42e7-93da-8ebb9b7b5381', N'Phân loại sản phẩm', N'Sắp xếp và phân loại sản phẩm một cách hiệu quả khi mua sắm tại các cửa hàng và siêu thị'),
('9932d1a2-1ad1-414a-9b75-64efbfc16183', N'Đàm phán giá cả', N'Kỹ năng đàm phán giá cả với người bán hàng để đảm bảo bạn có được giá ưu đãi nhất cho sản phẩm'),
('ae58cea3-240a-4ae1-969d-bd79a3ae812d', N'Tìm kiếm sản phẩm phù hợp', N'Nắm bắt nhu cầu và tìm kiếm các sản phẩm phù hợp nhất với yêu cầu của khách hàng'),
('a632afda-89b8-46eb-9077-360263230ac3', N'Kiểm tra chất lượng sản phẩm', N'Kiểm tra và đánh giá chất lượng của sản phẩm để đảm bảo bạn mua được hàng chất lượng nhất'),
('850d7b5d-5176-4c42-b2e5-c4c7d5870dce', N'Hiểu biết về giá cả và thị trường', N'Có kiến thức vững về giá cả và thị trường để có thể chọn lựa và mua sắm một cách thông minh'),
('b344f38a-e727-4ee9-8788-fe2b86930ae1', N'Chuẩn bị thực đơn đa dạng', N'Tạo ra thực đơn đa dạng và phong phú phục vụ nhu cầu ẩm thực của khách hàng'),
('cf707aab-5949-4a44-9312-e65ef934f088', N'Kỹ năng nấu ăn chuyên nghiệp', N'Sử dụng kỹ thuật nấu ăn chuyên nghiệp để tạo ra các món ăn ngon miệng và hấp dẫn'),
('54fbabe9-2b70-430f-bb47-da0ef1bf7ed9', N'Quản lý thời gian và nguyên liệu', N'Quản lý thời gian và nguyên liệu một cách hiệu quả để chuẩn bị và nấu các bữa ăn đúng thời hạn và chất lượng'),
('1018f7d5-d4ef-47a1-873d-085588426c72', N'Sáng tạo trong việc nấu ăn', N'Phát triển và áp dụng ý tưởng sáng tạo để tạo ra các món ăn mới và độc đáo'),
('536af6c4-fc9a-4fd5-89bb-cb592ed316af', N'Kỹ năng trình bày món ăn', N'Biến các món ăn trở nên hấp dẫn và bắt mắt thông qua kỹ năng trình bày món ăn sáng tạo'),
('11b3ca41-d04f-43b4-8f2b-a7dec67d9c61', N'Phân loại và sắp xếp quần áo', N'Hiểu biết về cách phân loại và sắp xếp quần áo một cách hiệu quả để tiện cho quá trình giặt ủi'),
('b07a9fc1-c869-4e35-adbe-b2e2627eed68', N'Xử lý quần áo nhạy cảm', N'Xử lý và giặt ủi quần áo có chất liệu nhạy cảm một cách cẩn thận và chuyên nghiệp'),
('0040bf7b-b8d9-46a2-b0d1-54d5e3a6aa76', N'Sử dụng máy giặt và máy sấy hiệu quả', N'Hiểu biết và sử dụng các thiết bị giặt ủi hiện đại một cách hiệu quả và tiết kiệm thời gian'),
('0e3c1e2b-f67e-4581-90c6-c9190c33f31f', N'Biết cách ủi quần áo một cách chuyên nghiệp', N'Hiểu biết về kỹ thuật và phương pháp ủi quần áo một cách chuyên nghiệp và linh hoạt'),
('b5a7fe43-e952-442a-a15a-8e8d89367462', N'Xử lý vết bẩn cứng đầu', N'Xử lý và loại bỏ các vết bẩn cứng đầu trên quần áo một cách hiệu quả và an toàn'),
('6666ca1d-2d5d-4764-b1bc-ad3fd3740058', N'Kiểm tra và chẩn đoán sự cố máy lạnh', N'Thực hiện kiểm tra kỹ thuật và chẩn đoán sự cố của máy lạnh để xác định nguyên nhân gây ra vấn đề'),
('2ef9de7c-98e7-4cf9-9258-ad1ae383a55e', N'Tháo lắp và lắp đặt máy lạnh', N'Thực hiện tháo lắp và lắp đặt máy lạnh một cách chuyên nghiệp và an toàn'),
('44adce9b-bbf2-4838-99bb-070ab14d3919', N'Bảo dưỡng định kỳ máy lạnh', N'Thực hiện bảo dưỡng định kỳ để đảm bảo máy lạnh hoạt động ổn định và hiệu quả'),
('0c5d44bc-db1c-4848-8d41-6788a7cfd0c5', N'Sửa chữa và thay thế linh kiện máy lạnh', N'Thực hiện sửa chữa và thay thế linh kiện máy lạnh hỏng hóc để khôi phục hoạt động của máy'),
('9491bccd-37b3-4796-a25d-be30a08c3541', N'Kiểm tra hiệu suất làm việc của máy lạnh', N'Đánh giá và kiểm tra hiệu suất làm việc của máy lạnh để đảm bảo hoạt động hiệu quả và tiết kiệm năng lượng'),
('c300ad2d-661e-4c0c-bd81-14e95c2d48a8', N'Phát hiện và sửa chữa rò rỉ', N'Phát hiện và khắc phục các vấn đề liên quan đến rò rỉ trong hệ thống ống nước'),
('423d0985-2f02-4e2a-bf23-1a37fcc3e4be', N'Thay thế ống nước hỏng', N'Tháo dỡ và thay thế các ống nước bị hỏng bằng các vật liệu chất lượng cao'),
('e9061193-6885-4e80-8539-24edabba06a3', N'Kiểm tra và bảo dưỡng hệ thống ống nước', N'Kiểm tra và thực hiện bảo dưỡng định kỳ cho hệ thống ống nước để đảm bảo hoạt động ổn định'),
('a825708a-a9e0-405e-86ae-2ac123a109ec', N'Sửa chữa vòi sen và bồn cầu', N'Sửa chữa và bảo dưỡng các vòi sen và bồn cầu để đảm bảo hoạt động hiệu quả'),
('9a9c5c0d-66b8-477d-a64d-c3d951848b29', N'Lắp đặt hệ thống ống nước mới', N'Lắp đặt hệ thống ống nước mới hoặc mở rộng hệ thống hiện có theo yêu cầu của khách hàng'),
('6615fcb9-deb5-4c89-9f75-b3f1cb77e477', N'Sửa chữa sàn gỗ', N'Chuyên sửa chữa và bảo dưỡng sàn gỗ một cách chuyên nghiệp và hiệu quả'),
('2b1e2526-ad8d-458f-84e9-48268d3a8bc6', N'Làm mới sàn gạch', N'Tạo ra sự mới mẻ và đẹp mắt cho sàn gạch bằng các phương pháp làm mới chuyên nghiệp'),
('4eea13e9-ee0a-4cd3-aa06-674eee41ba15', N'Bảo dưỡng sàn đá', N'Bảo dưỡng và làm sạch sàn đá để giữ cho nó luôn bền đẹp và bền vững'),
('3cde8b05-8857-4095-ae34-2388546c5b76', N'Sửa chữa sàn nhựa', N'Thực hiện các công việc sửa chữa và bảo dưỡng cho sàn nhựa để tăng tuổi thọ và độ bền của nó'),
('4c64db45-bdfe-4931-b9c8-305f30b1cc50', N'Làm mới sàn gỗ', N'Tạo ra sự mới mẻ và đẹp mắt cho sàn gỗ bằng các phương pháp làm mới chuyên nghiệp'),
('18305470-b98f-4c23-9ca4-86e6c7dbeac3', N'Dọn dẹp phòng khách', N'Dọn dẹp và sắp xếp lại không gian phòng khách của căn nhà một cách sạch sẽ và gọn gàng'),
('486b0bb3-5ad8-46f8-b299-3e79a9f0009a', N'Lau chùi bếp', N'Lau sạch bếp và các bề mặt liên quan để đảm bảo sự sạch sẽ và an toàn trong quá trình nấu nướng'),
('2c6a5f4e-ecab-4fe6-9035-bb33dc270708', N'Dọn dẹp phòng ngủ', N'Dọn dẹp và sắp xếp lại không gian phòng ngủ để tạo cảm giác thoải mái và thư giãn'),
('09630a6b-1cef-4a43-9755-ca42ec41d6c9', N'Lau dọn nhà tắm', N'Lau sạch và vệ sinh nhà tắm để đảm bảo vệ sinh cá nhân và sự thoải mái khi sử dụng'),
('cd06292a-e708-4c38-89f0-716041b77623', N'Dọn dẹp sân vườn', N'Dọn dẹp và bảo quản sân vườn để tạo một không gian ngoại thất sạch sẽ và thú vị'),
('0d394998-765f-45c5-ad29-c83aca9aed63', N'Lau chùi sàn nhà', N'Làm sạch và lau chùi các loại sàn nhà một cách kỹ lưỡng và hiệu quả'),
('9a9ef12b-04bd-4767-8bd7-4542c324ceda', N'Vệ sinh bề mặt', N'Sử dụng các phương pháp vệ sinh chuyên nghiệp để làm sạch bề mặt của căn nhà'),
('ec7c0211-b574-494f-b3bf-0425dfa9f8a8', N'Đánh bóng sàn nhà', N'Sử dụng các kỹ thuật đánh bóng chuyên nghiệp để làm cho sàn nhà trở nên sáng bóng'),
('42634124-88ef-4bb5-a40c-d7202c8289df', N'Vệ sinh nội thất', N'Lau chùi và vệ sinh các bề mặt nội thất như bàn ghế, kệ sách và đồ nội thất khác'),
('af4ff758-c07f-4d08-8a58-78af1dc0ca1c', N'Sơn phủ bề mặt', N'Sử dụng kỹ thuật sơn phủ chuyên nghiệp để làm mới và bảo vệ các bề mặt cần thiết'),
('7c244170-3402-41d8-8101-e162192e66c9', N'Quản lý lịch trình dọn dẹp', N'Lập kế hoạch và quản lý lịch trình dọn dẹp văn phòng hiệu quả'),
('9b5474fc-710e-4c94-943f-5bb84d075eb7', N'Xử lý và tái chế rác thải văn phòng', N'Xử lý và tái chế rác thải văn phòng một cách bền vững và hiệu quả'),
('66ba19f3-eb18-48e3-a95e-92e2146f886e', N'Sử dụng thiết bị dọn dẹp hiện đại', N'Sử dụng và vận hành các thiết bị dọn dẹp hiện đại để tăng hiệu suất và chất lượng dọn dẹp'),
('e5576d0a-1a33-4f62-bbe2-e870b29bdd71', N'Bố trí không gian văn phòng hợp lý', N'Bố trí không gian văn phòng một cách hợp lý để tối ưu hóa không gian làm việc'),
('56a8aa43-eb9a-4fd2-bf4f-3508a5e83c95', N'Xử lý và bảo quản tài liệu văn phòng', N'Xử lý và bảo quản tài liệu văn phòng một cách cẩn thận và tổ chức'),
('36fdb857-9e01-4c1c-b42c-ad9ff4f180a2', N'Làm sạch cửa sổ cẩn thận', N'Thực hiện việc làm sạch cửa sổ một cách cẩn thận và kỹ lưỡng để loại bỏ mọi vết bẩn và bụi bẩn'),
('a5d0a653-403d-4895-87e5-94cfafa8c974', N'Làm sạch kính trong suốt', N'Đảm bảo việc làm sạch kính một cách hoàn hảo để giữ cho cửa sổ luôn trong suốt'),
('5faa940a-9183-4885-907d-8f344f65a150', N'Lau chùi khung cửa chính xác', N'Thực hiện việc lau chùi khung cửa một cách chính xác và cẩn thận để đảm bảo sự sạch sẽ và bền bỉ'),
('dd04e3ae-8117-4540-ae3a-78e737ba351c', N'Sử dụng sản phẩm làm sạch chuyên nghiệp', N'Sử dụng các sản phẩm làm sạch chuyên nghiệp và hiệu quả để đạt được kết quả tốt nhất khi làm sạch cửa sổ'),
('6feffc0d-41ba-4e09-bbd8-2653f62dfffe', N'Xử lý các vết bẩn cứng đầu', N'Xử lý các vết bẩn khó chịu và cứng đầu trên cửa sổ một cách hiệu quả và nhanh chóng'),
('502d31b8-d89b-4946-a11d-14fbdb3909b4', N'Sử dụng thiết bị làm sạch chuyên nghiệp', N'Sử dụng các thiết bị và hóa chất làm sạch chuyên nghiệp để đảm bảo hiệu quả cao trong việc vệ sinh thảm văn phòng'),
('4b5bdfb7-5747-4d13-976a-c75a04ed0cbd', N'Thực hiện phương pháp làm sạch đa dạng', N'Áp dụng nhiều phương pháp làm sạch khác nhau tùy thuộc vào loại thảm và mức độ bẩn để đạt được kết quả tối ưu'),
('901b1065-716e-4551-aaa7-10022e81a8bb', N'Kiểm tra và loại bỏ vi khuẩn', N'Kiểm tra và áp dụng các biện pháp để loại bỏ vi khuẩn và vi sinh vật gây hại khác trong thảm văn phòng'),
('ed55b369-3f91-4b95-9ee6-36fdbba84550', N'Bảo dưỡng thảm vệ sinh định kỳ', N'Thực hiện các biện pháp bảo dưỡng định kỳ để giữ cho thảm văn phòng luôn sạch và tránh tình trạng bám bụi, bẩn'),
('dd3ed168-3f96-4c74-b508-94d620804779', N'Kiểm tra và làm sạch lọc khí', N'Kiểm tra và làm sạch lọc khí của máy lạnh để cải thiện chất lượng không khí'),
('bf45b2db-80ef-4fe4-80ec-e20f9b143bd4', N'Kiểm tra và nạp gas làm lạnh', N'Kiểm tra và nạp gas làm lạnh cho hệ thống máy lạnh để duy trì hiệu suất làm việc tốt nhất'),
('5c28ddbb-358e-45e6-b1d1-b451dc504a94', N'Vệ sinh và xử lý rò rỉ nước', N'Vệ sinh và xử lý rò rỉ nước trong hệ thống máy lạnh để đảm bảo hoạt động hiệu quả'),
('a82e981e-5df8-496b-9985-12cd638d1a13', N'Kiểm tra và điều chỉnh áp suất', N'Kiểm tra và điều chỉnh áp suất của hệ thống máy lạnh để đảm bảo hoạt động ổn định'),
('735a7f99-bc24-48a7-b2f8-140957b0b9eb', N'Kiểm tra và làm sạch cánh quạt', N'Kiểm tra và làm sạch cánh quạt của máy lạnh để đảm bảo tuổi thọ và hiệu suất của máy'); 

INSERT INTO [SkillServiceTypes] ([SkillId], [ServiceTypeId]) VALUES
('d4c95511-492f-46aa-8326-84299acbe8fd', '7986a30b-5b5e-4d9d-9446-1d554d11055f'),
('510acfa4-eddb-4d08-b4ce-30ebf132922f', '7986a30b-5b5e-4d9d-9446-1d554d11055f'),
('28c41f96-ad80-457f-b59b-e948d1bd9135', '7986a30b-5b5e-4d9d-9446-1d554d11055f'),
('28c41f96-ad80-457f-b59b-e948d1bd9135', '8a4ad0e1-16fd-457e-a6f0-16accaf8e764'),
('92fd24e8-abeb-45d3-a33c-02d24224b78d', '7986a30b-5b5e-4d9d-9446-1d554d11055f'),
('e7978b8d-a546-4133-a576-778f34985d06', '7986a30b-5b5e-4d9d-9446-1d554d11055f'),
('d9b6ce05-94a3-4781-976d-707579d6fe5f', '530d29ca-17a1-4db9-a569-09a17e30b0af'),
('657fabfe-88db-46b4-ba2c-947f36b0ea45', '530d29ca-17a1-4db9-a569-09a17e30b0af'),
('db42a4fc-a790-4706-bd0b-c263dbbc2522', '530d29ca-17a1-4db9-a569-09a17e30b0af'),
('562bb844-3fe4-486c-94a6-28876cdb287d', '530d29ca-17a1-4db9-a569-09a17e30b0af'),
('126d9bee-996a-4880-b54e-a2ee84b5e822', '530d29ca-17a1-4db9-a569-09a17e30b0af'),
('44c2a6e0-9437-4bee-b150-ffe0dc1b1c37', '9f6bf976-ec5d-4e31-bfeb-7aea7637f20e'),
('049657d4-138c-4d0b-8d56-245e7f0a841d', '9f6bf976-ec5d-4e31-bfeb-7aea7637f20e'),
('a9b4b60a-999d-463e-9d75-5ba249c3c91f', '9f6bf976-ec5d-4e31-bfeb-7aea7637f20e'),
('8837d38a-d219-40f5-9bc7-b439e69d17d2', '9f6bf976-ec5d-4e31-bfeb-7aea7637f20e'),
('b6f8ae11-db74-4c55-a9d7-f8904d4d5825', '9f6bf976-ec5d-4e31-bfeb-7aea7637f20e'),
('59a05b2f-2857-49e0-a5dc-7e1746480dce', 'b1c2cd51-bbe5-4b95-bcf4-3f04b57357d0'),
('e9d1a4d9-053f-4a60-a67e-3d59a11feeeb', 'b1c2cd51-bbe5-4b95-bcf4-3f04b57357d0'),
('3eda0312-2f58-4f02-852d-bec6e4bc344b', 'b1c2cd51-bbe5-4b95-bcf4-3f04b57357d0'),
('d2fa3f68-6d70-4707-adda-0268312c25ee', 'b1c2cd51-bbe5-4b95-bcf4-3f04b57357d0'),
('34698e8c-7ba7-4f52-851b-e2bf6c10426b', 'b1c2cd51-bbe5-4b95-bcf4-3f04b57357d0'),
('7a5066e5-c755-4f49-9afa-0813626afb04', '8a4ad0e1-16fd-457e-a6f0-16accaf8e764'),
('fc77b33f-5f6e-4495-9837-14d8a049882d', '8a4ad0e1-16fd-457e-a6f0-16accaf8e764'),
('8953f6d9-1e51-4907-b8ee-44cb5b4787d0', '8a4ad0e1-16fd-457e-a6f0-16accaf8e764'),
('43bcbdaf-3cd6-44e4-add3-aec51dcf2c7d', '8a4ad0e1-16fd-457e-a6f0-16accaf8e764'),
('919b1e17-6392-42e7-93da-8ebb9b7b5381', 'f146cba9-72a1-47be-a36d-9bf6407f59d9'),
('9932d1a2-1ad1-414a-9b75-64efbfc16183', 'f146cba9-72a1-47be-a36d-9bf6407f59d9'),
('ae58cea3-240a-4ae1-969d-bd79a3ae812d', 'f146cba9-72a1-47be-a36d-9bf6407f59d9'),
('a632afda-89b8-46eb-9077-360263230ac3', 'f146cba9-72a1-47be-a36d-9bf6407f59d9'),
('850d7b5d-5176-4c42-b2e5-c4c7d5870dce', 'f146cba9-72a1-47be-a36d-9bf6407f59d9'),
('b344f38a-e727-4ee9-8788-fe2b86930ae1', '531f4e94-1880-4d31-b001-6f59ff0322f0'),
('cf707aab-5949-4a44-9312-e65ef934f088', '531f4e94-1880-4d31-b001-6f59ff0322f0'),
('54fbabe9-2b70-430f-bb47-da0ef1bf7ed9', '531f4e94-1880-4d31-b001-6f59ff0322f0'),
('1018f7d5-d4ef-47a1-873d-085588426c72', '531f4e94-1880-4d31-b001-6f59ff0322f0'),
('536af6c4-fc9a-4fd5-89bb-cb592ed316af', '531f4e94-1880-4d31-b001-6f59ff0322f0'),
('11b3ca41-d04f-43b4-8f2b-a7dec67d9c61', 'dc3262c0-6cf9-4058-be3c-98e4bb401ada'),
('b07a9fc1-c869-4e35-adbe-b2e2627eed68', 'dc3262c0-6cf9-4058-be3c-98e4bb401ada'),
('0040bf7b-b8d9-46a2-b0d1-54d5e3a6aa76', 'dc3262c0-6cf9-4058-be3c-98e4bb401ada'),
('0e3c1e2b-f67e-4581-90c6-c9190c33f31f', 'dc3262c0-6cf9-4058-be3c-98e4bb401ada'),
('b5a7fe43-e952-442a-a15a-8e8d89367462', 'dc3262c0-6cf9-4058-be3c-98e4bb401ada'),
('b5a7fe43-e952-442a-a15a-8e8d89367462', '4a6fc79c-35bf-45cc-99c3-9bb0707a2883'),
('6666ca1d-2d5d-4764-b1bc-ad3fd3740058', '80998115-c96e-43f8-80b9-2c37272be33f'),
('2ef9de7c-98e7-4cf9-9258-ad1ae383a55e', '80998115-c96e-43f8-80b9-2c37272be33f'),
('44adce9b-bbf2-4838-99bb-070ab14d3919', '80998115-c96e-43f8-80b9-2c37272be33f'),
('0c5d44bc-db1c-4848-8d41-6788a7cfd0c5', '80998115-c96e-43f8-80b9-2c37272be33f'),
('9491bccd-37b3-4796-a25d-be30a08c3541', '80998115-c96e-43f8-80b9-2c37272be33f'),
('c300ad2d-661e-4c0c-bd81-14e95c2d48a8', '509827e5-0852-4ea2-9fa4-7551bbbf88d9'),
('423d0985-2f02-4e2a-bf23-1a37fcc3e4be', '509827e5-0852-4ea2-9fa4-7551bbbf88d9'),
('e9061193-6885-4e80-8539-24edabba06a3', '509827e5-0852-4ea2-9fa4-7551bbbf88d9'),
('a825708a-a9e0-405e-86ae-2ac123a109ec', '509827e5-0852-4ea2-9fa4-7551bbbf88d9'),
('9a9c5c0d-66b8-477d-a64d-c3d951848b29', '509827e5-0852-4ea2-9fa4-7551bbbf88d9'),
('6615fcb9-deb5-4c89-9f75-b3f1cb77e477', '9fb42b78-0266-4222-a923-11d1d54ec673'),
('2b1e2526-ad8d-458f-84e9-48268d3a8bc6', '9fb42b78-0266-4222-a923-11d1d54ec673'),
('4eea13e9-ee0a-4cd3-aa06-674eee41ba15', '9fb42b78-0266-4222-a923-11d1d54ec673'),
('3cde8b05-8857-4095-ae34-2388546c5b76', '9fb42b78-0266-4222-a923-11d1d54ec673'),
('4c64db45-bdfe-4931-b9c8-305f30b1cc50', '9fb42b78-0266-4222-a923-11d1d54ec673'),
('18305470-b98f-4c23-9ca4-86e6c7dbeac3', '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('486b0bb3-5ad8-46f8-b299-3e79a9f0009a', '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('2c6a5f4e-ecab-4fe6-9035-bb33dc270708', '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('09630a6b-1cef-4a43-9755-ca42ec41d6c9', '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('cd06292a-e708-4c38-89f0-716041b77623', '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('0d394998-765f-45c5-ad29-c83aca9aed63', 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('9a9ef12b-04bd-4767-8bd7-4542c324ceda', 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('ec7c0211-b574-494f-b3bf-0425dfa9f8a8', 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('42634124-88ef-4bb5-a40c-d7202c8289df', 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('af4ff758-c07f-4d08-8a58-78af1dc0ca1c', 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('7c244170-3402-41d8-8101-e162192e66c9', 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('9b5474fc-710e-4c94-943f-5bb84d075eb7', 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('66ba19f3-eb18-48e3-a95e-92e2146f886e', 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('e5576d0a-1a33-4f62-bbe2-e870b29bdd71', 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('56a8aa43-eb9a-4fd2-bf4f-3508a5e83c95', 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('36fdb857-9e01-4c1c-b42c-ad9ff4f180a2', '79e7bb6a-4c26-4444-b7b2-4e95060bc3b6'),
('a5d0a653-403d-4895-87e5-94cfafa8c974', '79e7bb6a-4c26-4444-b7b2-4e95060bc3b6'),
('5faa940a-9183-4885-907d-8f344f65a150', '79e7bb6a-4c26-4444-b7b2-4e95060bc3b6'),
('dd04e3ae-8117-4540-ae3a-78e737ba351c', '79e7bb6a-4c26-4444-b7b2-4e95060bc3b6'),
('6feffc0d-41ba-4e09-bbd8-2653f62dfffe', '79e7bb6a-4c26-4444-b7b2-4e95060bc3b6'),
('502d31b8-d89b-4946-a11d-14fbdb3909b4', '4a6fc79c-35bf-45cc-99c3-9bb0707a2883'),
('4b5bdfb7-5747-4d13-976a-c75a04ed0cbd', '4a6fc79c-35bf-45cc-99c3-9bb0707a2883'),
('901b1065-716e-4551-aaa7-10022e81a8bb', '4a6fc79c-35bf-45cc-99c3-9bb0707a2883'),
('ed55b369-3f91-4b95-9ee6-36fdbba84550', '4a6fc79c-35bf-45cc-99c3-9bb0707a2883'),
('dd3ed168-3f96-4c74-b508-94d620804779', '036b78bd-630e-4553-ae22-81a938c96112'),
('bf45b2db-80ef-4fe4-80ec-e20f9b143bd4', '036b78bd-630e-4553-ae22-81a938c96112'),
('5c28ddbb-358e-45e6-b1d1-b451dc504a94', '036b78bd-630e-4553-ae22-81a938c96112'),
('a82e981e-5df8-496b-9985-12cd638d1a13', '036b78bd-630e-4553-ae22-81a938c96112'),
('735a7f99-bc24-48a7-b2f8-140957b0b9eb', '036b78bd-630e-4553-ae22-81a938c96112'); 

INSERT INTO [FreelanceSkills] ([FreelancerId], [SkillId]) VALUES
('aa1f6884-b260-4011-a3b8-99aa05fc2258', '59a05b2f-2857-49e0-a5dc-7e1746480dce'),
('aa1f6884-b260-4011-a3b8-99aa05fc2258', 'a5d0a653-403d-4895-87e5-94cfafa8c974'),
('aa1f6884-b260-4011-a3b8-99aa05fc2258', '0c5d44bc-db1c-4848-8d41-6788a7cfd0c5'),
('9378f86c-81c0-4e68-b10e-47f69ffb7580', '54fbabe9-2b70-430f-bb47-da0ef1bf7ed9'); 

INSERT INTO [UIElementInputMethodTypes] ([Name], [Id]) VALUES
('select', '291ba660-444a-4bb9-a602-ec0f748772c4'),
('inputText', '63769d6f-7e5e-4419-8703-9a1a06e2bcac'),
('select', 'a23cecd2-00d7-45dc-a67c-0fbd9941eaca'),
('inputNumber', '2c2ed2b1-591d-4479-8c5c-d86581c2295e'),
('select', 'a0b36f53-328a-4702-9f6f-fb70687b4e25'),
('inputText', 'df4bea7a-9832-4b75-81f8-e59b6f26c1b2'),
('inputNumber', '169d6ad8-6673-443d-8d6b-809173760564'),
('inputText', 'e3942881-5fee-48ef-9173-62bccc62d24b'),
('inputText', 'c7a4d284-fced-440d-a842-2e2617c32ae6'),
('inputNumber', 'd72e79d7-4d09-4c7d-8833-da08ee714079'),
('select', 'f3bc9671-8935-4242-b648-b79497c71062'),
('inputText', '3606ea83-2ac4-4076-8fdc-d60d1c9d129c'),
('selectInputNumber', 'fb1402db-4cd5-4717-ad58-e116aab61033'),
('select', 'dbc0161f-0291-42c2-a590-569f53dd56ed'),
('inputText', '1cafcbb3-1158-409b-aba0-73e08ea13e5e'),
('selectInputNumber', '09dd1d79-27a0-439b-829d-7d9e7eeeca72'),
('inputText', 'a37a0718-8009-4018-8e65-199d6e0ad64c'),
('multiSelect', '84ad7a1b-4cba-433c-a359-34e9ca0c0adb'); 

INSERT INTO [UIElementInputOptions] ([Id], [Name], [Description], [InputMethodTypeId]) VALUES
('a80e5f8b-f8fa-4758-b669-5d2823ce34db', N'Nhà ở, nhà phố', N'Mô tả để kiểm tra', '291ba660-444a-4bb9-a602-ec0f748772c4'),
('8d6f3d29-28d1-4b22-9dcb-65bd34a15e43', N'Căn hộ', N'Mô tả để kiểm tra', '291ba660-444a-4bb9-a602-ec0f748772c4'),
('9e1bece3-3064-45f4-b4ce-3f6928094ad0', N'Biệt thự', N'Mô tả để kiểm tra', '291ba660-444a-4bb9-a602-ec0f748772c4'),
('1a173638-2ef1-412a-865f-c82e67815a7e', N'Phòng trọ', N'Mô tả để kiểm tra', '291ba660-444a-4bb9-a602-ec0f748772c4'),
('5c850687-9eee-4adc-a75c-b57fcf79b59f', N'Dọn trọn gói', N'Tất cả dịch vụ, dọn toàn bộ nhà / phòng', 'a23cecd2-00d7-45dc-a67c-0fbd9941eaca'),
('b250937d-5093-4902-9c9e-9af2dde9db68', N'Dọn theo phòng', N'Tính phí dọn theo từng phòng, tiết kiệm và nhanh chóng', 'a23cecd2-00d7-45dc-a67c-0fbd9941eaca'),
('f250a0e6-84d8-48d4-a3ec-e21726184d63', N'Nhà ở, nhà phố', N'Mô tả để kiểm tra', 'a0b36f53-328a-4702-9f6f-fb70687b4e25'),
('6e670daa-52ee-4976-8a88-9abf367bb16f', N'Căn hộ', N'Mô tả để kiểm tra', 'a0b36f53-328a-4702-9f6f-fb70687b4e25'),
('4fd502b2-8647-46fb-b290-8b9f5101d02e', N'Biệt thự', N'Mô tả để kiểm tra', 'a0b36f53-328a-4702-9f6f-fb70687b4e25'),
('6a77a75b-22e5-4a25-8e22-33b0512664b4', N'Phòng trọ', N'Mô tả để kiểm tra', 'a0b36f53-328a-4702-9f6f-fb70687b4e25'),
('537537df-e953-499b-ac2c-f69b81b3082b', N'Nhà ở, nhà phố', N'Mô tả để kiểm tra', 'f3bc9671-8935-4242-b648-b79497c71062'),
('b45ef714-e627-4e55-8db6-dbc5b3193fc8', N'Căn hộ', N'Mô tả để kiểm tra', 'f3bc9671-8935-4242-b648-b79497c71062'),
('ffcdbe1c-8554-42bc-96a9-3c50a4d6d296', N'Biệt thự', N'Mô tả để kiểm tra', 'f3bc9671-8935-4242-b648-b79497c71062'),
('6160a940-d006-488a-bbeb-1cc3688d855a', N'Phòng trọ', N'Mô tả để kiểm tra', 'f3bc9671-8935-4242-b648-b79497c71062'),
('77d827e4-88be-4518-a6e3-387246f41df0', N'Nhà ở, nhà phố', N'Mô tả để kiểm tra', 'dbc0161f-0291-42c2-a590-569f53dd56ed'),
('c09f6b88-b1ea-49ac-a7c3-2137b9554bf5', N'Căn hộ', N'Mô tả để kiểm tra', 'dbc0161f-0291-42c2-a590-569f53dd56ed'),
('2f70f21e-ce5b-40d6-b35a-b8be69e78d64', N'Biệt thự', N'Mô tả để kiểm tra', 'dbc0161f-0291-42c2-a590-569f53dd56ed'),
('a0f4643e-bf04-4898-99ac-e4629af1d7fd', N'Phòng trọ', N'Mô tả để kiểm tra', 'dbc0161f-0291-42c2-a590-569f53dd56ed'),
('467a0a6d-ed55-497f-8c8a-d52f0139c551', N'Treo tường', 'UPDATE LATER', '84ad7a1b-4cba-433c-a359-34e9ca0c0adb'),
('3e873078-a7aa-417f-afd5-38bb79f8cb42', N'Tủ đứng', 'UPDATE LATER', '84ad7a1b-4cba-433c-a359-34e9ca0c0adb'),
('bd1a7d23-660c-4c44-baf1-e01a6cc9c746', N'Âm trần', 'UPDATE LATER', '84ad7a1b-4cba-433c-a359-34e9ca0c0adb'),
('115333da-8902-473c-8c57-02449d67c8b1', N'Áp trần', 'UPDATE LATER', '84ad7a1b-4cba-433c-a359-34e9ca0c0adb'),
('460e3334-c3dd-466c-9c01-3084865b8f6e', N'Giấu trần', 'UPDATE LATER', '84ad7a1b-4cba-433c-a359-34e9ca0c0adb'); 

INSERT INTO [UIElementServiceRequirementInputMethods] ([DataType], [MethodId], [Id]) VALUES
('text', '291ba660-444a-4bb9-a602-ec0f748772c4', 'cbccc7fe-825a-4c47-a9e9-e7b0614c3b26'),
('text', '63769d6f-7e5e-4419-8703-9a1a06e2bcac', '8fbd0415-ea94-40b8-b735-d58df8901b45'),
('text', 'a23cecd2-00d7-45dc-a67c-0fbd9941eaca', '630c1367-cb6f-4fe8-8c24-3aa93df3eb45'),
('number', '2c2ed2b1-591d-4479-8c5c-d86581c2295e', '187ab0b0-d162-4882-835c-d9d574afd2c8'),
('text', 'a0b36f53-328a-4702-9f6f-fb70687b4e25', 'b2735aa3-14bd-4c04-8e5f-f45710c84548'),
('text', 'df4bea7a-9832-4b75-81f8-e59b6f26c1b2', 'db0cfc89-38fb-4737-adfb-f7f6163aa057'),
('number', '169d6ad8-6673-443d-8d6b-809173760564', 'f7a7f5f3-350b-4071-b2ef-13f36c9f05db'),
('text', 'e3942881-5fee-48ef-9173-62bccc62d24b', '98df407a-6d78-460a-ac95-aad29ebaf78a'),
('text', 'c7a4d284-fced-440d-a842-2e2617c32ae6', '55ab1efb-6b03-4e54-bdad-6044a1f311c3'),
('number', 'd72e79d7-4d09-4c7d-8833-da08ee714079', '1cc17ae5-e612-485d-a1c0-636f90adb26a'),
('text', 'f3bc9671-8935-4242-b648-b79497c71062', '8c094a52-347f-4a21-8f16-992de47b21d6'),
('text', '3606ea83-2ac4-4076-8fdc-d60d1c9d129c', '2270911a-e79b-490c-abfd-074710caf43f'),
('number', 'fb1402db-4cd5-4717-ad58-e116aab61033', '3d33182b-a383-41f9-9289-86b59b512afc'),
('text', 'dbc0161f-0291-42c2-a590-569f53dd56ed', 'f4927c73-54dc-41e1-84a4-26cb5b6a5460'),
('text', '1cafcbb3-1158-409b-aba0-73e08ea13e5e', 'f7f3b670-f231-4b4a-851a-45ac1bda8a16'),
('number', '09dd1d79-27a0-439b-829d-7d9e7eeeca72', '540fa482-1475-4ec6-a74a-c809c0f96791'),
('text', 'a37a0718-8009-4018-8e65-199d6e0ad64c', '8e2f418c-9e49-4142-911d-8bc9c489de3a'),
('text', '84ad7a1b-4cba-433c-a359-34e9ca0c0adb', '5321728a-9ad7-4e06-a0e3-128c8172a688'); 

INSERT INTO [UIElementValidationTypes] ([Id], [Name], [Value], [Message], [InputMethodId]) VALUES
('93216dcb-afd4-4d75-92e1-456aa2475daf', 'required', null, N'Vui lòng điền đầy đủ thông tin', 'cbccc7fe-825a-4c47-a9e9-e7b0614c3b26'),
('b9d4640e-38eb-4e36-afce-63ef4f3abe4f', 'required', null, N'Vui lòng điền đầy đủ thông tin', '8fbd0415-ea94-40b8-b735-d58df8901b45'),
('7c408fb7-a891-4d84-befb-af1818e640ef', 'max', 255, N'Tin nhắn thông báo mẫu', '8fbd0415-ea94-40b8-b735-d58df8901b45'),
('fcfbd315-de49-46ad-b6a4-d6e80712eed4', 'required', null, N'Vui lòng điền đầy đủ thông tin', '630c1367-cb6f-4fe8-8c24-3aa93df3eb45'),
('3f655cc2-0774-46a5-9c96-5ccb586862e3', 'min', 1, N'Số lượng phòng không được bé hơn 1', '187ab0b0-d162-4882-835c-d9d574afd2c8'),
('765a91b3-621d-450c-9189-6d75850d80a0', 'required', null, N'Vui lòng điền đầy đủ thông tin', 'b2735aa3-14bd-4c04-8e5f-f45710c84548'),
('7b9e7bb8-27ae-4e7a-b538-19ab94b297b4', 'required', null, N'Vui lòng điền đầy đủ thông tin', 'db0cfc89-38fb-4737-adfb-f7f6163aa057'),
('2588a86c-63e9-4a54-8ff7-552a952b4707', 'max', 255, N'Tin nhắn thông báo mẫu', 'db0cfc89-38fb-4737-adfb-f7f6163aa057'),
('3f909842-ec33-44a1-a5f2-f6cdc9dd0afd', 'min', 1, N'Số lượng phòng không được bé hơn 1', 'f7a7f5f3-350b-4071-b2ef-13f36c9f05db'),
('4bd6efe7-be9b-4919-8d68-c66db3706dc5', 'required', null, N'Vui lòng điền đầy đủ thông tin', '98df407a-6d78-460a-ac95-aad29ebaf78a'),
('d55c7a25-02ae-42bd-9ee0-6a69e22584c9', 'max', 255, N'Tin nhắn thông báo mẫu', '98df407a-6d78-460a-ac95-aad29ebaf78a'),
('3b40061c-c162-429a-9fc5-61b6ba9f8388', 'required', null, N'Vui lòng điền đầy đủ thông tin', '55ab1efb-6b03-4e54-bdad-6044a1f311c3'),
('f9c47b8e-0104-4ddb-8596-4f1d1332b18b', 'min', 0, N'Số lượng lầu không được bé hơn 0', '1cc17ae5-e612-485d-a1c0-636f90adb26a'),
('fc2cbe8e-dfcf-423d-a7ce-62f4375c69bc', 'required', null, N'Vui lòng điền đầy đủ thông tin', '8c094a52-347f-4a21-8f16-992de47b21d6'),
('addde48e-8bb0-4be7-9472-8869fc1dc45e', 'required', null, N'Vui lòng điền đầy đủ thông tin', '2270911a-e79b-490c-abfd-074710caf43f'),
('e1d741dc-18d4-4508-93df-1c2aa8102fb1', 'max', 255, N'Tin nhắn thông báo mẫu', '2270911a-e79b-490c-abfd-074710caf43f'),
('82c2cbc7-26ce-4bdb-b6a3-1bfc1663c3dc', 'min', 1, N'Số lượng cửa sổ không được bé hơn 1', '3d33182b-a383-41f9-9289-86b59b512afc'),
('7364095a-7ba1-4dab-bca4-ee107d265134', 'required', null, N'Vui lòng điền đầy đủ thông tin', 'f4927c73-54dc-41e1-84a4-26cb5b6a5460'),
('eb7bbb9a-b791-424c-986c-be0d15d02f6d', 'required', null, N'Vui lòng điền đầy đủ thông tin', 'f7f3b670-f231-4b4a-851a-45ac1bda8a16'),
('5aa98c2a-df06-4608-9eca-b3940b423a84', 'max', 255, N'Tin nhắn thông báo mẫu', 'f7f3b670-f231-4b4a-851a-45ac1bda8a16'),
('3a716b71-9de6-4314-a251-1c165feaf1a5', 'min', 1, N'Số lượng cửa sổ không được bé hơn 1', '540fa482-1475-4ec6-a74a-c809c0f96791'),
('2d21a812-e53d-43fd-996d-06234a4da4c8', 'required', null, N'Vui lòng điền đầy đủ thông tin', '8e2f418c-9e49-4142-911d-8bc9c489de3a'),
('360f4c68-fd5e-4a79-8f47-e5f250905226', 'max', 255, N'Tin nhắn thông báo mẫu', '8e2f418c-9e49-4142-911d-8bc9c489de3a'),
('428d680f-f76f-4ece-b403-ad53913f9014', 'required', null, N'Vui lòng điền đầy đủ thông tin', '5321728a-9ad7-4e06-a0e3-128c8172a688'),
('f22ddcdb-b0f8-429c-aef0-b981aaa1f8a4', 'min', 0, N'Số lượng máy lạnh không được bé hơn 0', '5321728a-9ad7-4e06-a0e3-128c8172a688'); 

INSERT INTO [UIElementServiceRequirements] ([Id], [Label], [LabelIcon], [Placeholder], [InputMethodId], [Key], [Priority], [ServiceTypeId]) VALUES
('90bcab20-07a1-4ea8-b38a-b5c289fa0026', N'Loại nhà', 'faHouse', N'Nhà, căn hộ, biệt thự ', 'cbccc7fe-825a-4c47-a9e9-e7b0614c3b26', 'loai_nha', 0, '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('e0b4297c-761e-4919-a597-6808a13c81ce', N'Số nhà, số phòng, sô lầu, hẻm (ngõ)', null, N'Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent', '8fbd0415-ea94-40b8-b735-d58df8901b45', 'so_nha,_so_phong,_so_lau,_hem_(ngo)', 1, '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('aa1c5070-4a3b-4921-b23a-303c278eda4a', N'Bạn muốn chúng tôi dọn như thế nào?', 'faFlag', N'Giúp nhân viên biết thêm về công việc cần làm', '630c1367-cb6f-4fe8-8c24-3aa93df3eb45', 'ban_muon_chung_toi_don_nhu_the_nao?', 2, '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('2a477e21-59d9-4943-9c49-6c43c1a947fd', N'Số lượng phòng', 'faHouse', N'Ví dụ: 1', '187ab0b0-d162-4882-835c-d9d574afd2c8', 'so_luong_phong', 3, '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('dae89124-8d82-45aa-9b3e-a67da21229b6', N'Loại nhà', 'faHouse', N'Nhà, căn hộ, biệt thự ', 'b2735aa3-14bd-4c04-8e5f-f45710c84548', 'loai_nha', 0, 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('92a08177-4252-4872-a6d4-325e8523e4bc', N'Số nhà, số phòng, sô lầu, hẻm (ngõ)', null, N'Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent', 'db0cfc89-38fb-4737-adfb-f7f6163aa057', 'so_nha,_so_phong,_so_lau,_hem_(ngo)', 1, 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('7b44bc5e-8d19-4382-801d-2c37844ad3a1', N'Số lượng phòng', 'faHouse', N'Ví dụ: 1', 'f7a7f5f3-350b-4071-b2ef-13f36c9f05db', 'so_luong_phong', 2, 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('706f4a2d-c29e-4d5e-86f9-41c085cd20c3', N'Số nhà, số phòng, số lầu, hẻm (ngõ)', null, N'Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent', '98df407a-6d78-460a-ac95-aad29ebaf78a', 'so_nha,_so_phong,_so_lau,_hem_(ngo)', 0, 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('937a2b71-8fbf-44d0-afb6-7d7999712375', N'Diện tích văn phòng', null, N'Ví dụ: 5x5m', '55ab1efb-6b03-4e54-bdad-6044a1f311c3', 'dien_tich_van_phong', 1, 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('26931966-2453-41db-976d-5e18a17fe6e4', N'Số lượng phòng', 'faHouse', N'Ví dụ: 1', '1cc17ae5-e612-485d-a1c0-636f90adb26a', 'so_luong_phong', 2, 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('72f67976-4a12-4fdd-b216-34adf35961a3', N'Loại nhà', 'faHouse', N'Nhà, căn hộ, biệt thự ', '8c094a52-347f-4a21-8f16-992de47b21d6', 'loai_nha', 0, '79e7bb6a-4c26-4444-b7b2-4e95060bc3b6'),
('b28ca07c-3c5f-455d-9220-5f449240acb4', N'Số nhà, số phòng, sô lầu, hẻm (ngõ)', null, N'Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent', '2270911a-e79b-490c-abfd-074710caf43f', 'so_nha,_so_phong,_so_lau,_hem_(ngo)', 1, '79e7bb6a-4c26-4444-b7b2-4e95060bc3b6'),
('1bf5dd1e-2251-4629-9086-7ccc090b4288', N'Số lượng cửa sổ', 'faHouse', N'Ví dụ: 1', '3d33182b-a383-41f9-9289-86b59b512afc', 'so_luong_cua_so', 2, '79e7bb6a-4c26-4444-b7b2-4e95060bc3b6'),
('4a7545ed-3236-4538-8dcb-39d9352a9a49', N'Loại nhà', 'faHouse', N'Nhà, căn hộ, biệt thự ', 'f4927c73-54dc-41e1-84a4-26cb5b6a5460', 'loai_nha', 0, '4a6fc79c-35bf-45cc-99c3-9bb0707a2883'),
('9dcad079-2f94-492a-bf1d-30db996f292d', N'Diện tích thảm văn phòng', null, N'Ví dụ: 5x5m', 'f7f3b670-f231-4b4a-851a-45ac1bda8a16', 'dien_tich_tham_van_phong', 1, '4a6fc79c-35bf-45cc-99c3-9bb0707a2883'),
('bb527972-9eba-4a2e-91f1-ac94b27b67ea', N'Loại thảm, Số lượng thảm', 'faHouse', N'Ví dụ: Thảm chà, số lượng 1', '540fa482-1475-4ec6-a74a-c809c0f96791', 'loai_tham,_so_luong_tham', 2, '4a6fc79c-35bf-45cc-99c3-9bb0707a2883'),
('44cb573d-be60-48fc-8e5e-96f341044343', N'Số nhà, số phòng, sô lầu, hẻm (ngõ)', null, N'Ví dụ: 257/43 Phòng 2014 Căn hộ Sunrise Continent', '8e2f418c-9e49-4142-911d-8bc9c489de3a', 'so_nha,_so_phong,_so_lau,_hem_(ngo)', 0, '036b78bd-630e-4553-ae22-81a938c96112'),
('7167fe8b-988c-43d7-a8ee-968506b95824', N'Loại máy lạnh', 'faHouse', N'Ví dụ: 1', '5321728a-9ad7-4e06-a0e3-128c8172a688', 'loai_may_lanh', 1, '036b78bd-630e-4553-ae22-81a938c96112'); 

INSERT INTO [UIElementAdditionServiceRequirements] ([Id], [Icon], [Label], [AutoSelect], [Key], [Priority], [ServiceTypeId]) VALUES
('0c294b58-1a15-41e7-8ac6-f8e278576e70', 'faDog', N'Nhà có thú cưng', 0, 'nha_co_thu_cung', 0, '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('87c3004b-db75-404b-bd62-f2f2c9776f87', 'faPC', N'Nhà có nhiều đồ điện tử', 0, 'nha_co_nhieu_do_dien_tu', 0, '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('8481b0fb-a9c9-41d2-8712-d47d62f2090e', 'faBroom', N'Nhân viên tự mang theo dụng cụ', 1, 'nhan_vien_tu_mang_theo_dung_cu', 0, '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('9b2fb3d0-f81a-4ae8-96cf-cc7a14a574de', 'faDog', N'Nhà có thú cưng', 0, 'nha_co_thu_cung', 0, 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('24dbcaed-62e4-4a92-9798-e4ced2295e31', 'faPC', N'Nhà có nhiều đồ điện tử', 0, 'nha_co_nhieu_do_dien_tu', 0, 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('bae990ed-9324-45be-9697-f915a6ca1ce5', 'faBroom', N'Nhân viên tự mang theo dụng cụ', 1, 'nhan_vien_tu_mang_theo_dung_cu', 0, 'fc1a6664-748c-4aa3-b7be-82300f8fdd0c'),
('ca9c8f09-8b1c-40ce-813f-1095cfa3bb71', 'faPC', N'Văn phòng có nhiều đồ điện tử', 0, 'van_phong_co_nhieu_do_dien_tu', 0, 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('f6057de7-54f4-4509-92ae-5265a5382fbc', 'faBroom', N'Nhân viên tự mang theo dụng cụ', 1, 'nhan_vien_tu_mang_theo_dung_cu', 0, 'ad460783-3b95-4057-a735-d73b491c2bd8'),
('0ffa5e83-d51e-4842-bd26-0527bd382e3b', 'faBroom', N'Nhân viên tự mang theo dụng cụ', 1, 'nhan_vien_tu_mang_theo_dung_cu', 0, '79e7bb6a-4c26-4444-b7b2-4e95060bc3b6'); 

INSERT INTO [Orders] ([Id], [AddressId], [EstimatedPrice], [StartTime], [FinishTime], [CreatedTime], [FreelancerId], [CustomerId], [Rating], [Comment], [ServiceStatusId]) VALUES
('bfa73a42-b0e0-4b98-a591-9a55f8f906cf', '0a3ef50a-d6d5-4957-86b4-469ca9089e2f', 0, '2024-03-20T00:00:00.000000', null, '2024-03-19T00:00:00.000000', null, 'b571706b-a3af-4dde-bb0d-25b5e0295500', 0, null, '8a9f22f1-3c67-49f7-bd84-ec290e4a37fd'),
('35c893a9-4b47-4a0f-8334-f41dc612579f', '0a3ef50a-d6d5-4957-86b4-469ca9089e2f', 200000, '2024-04-03T00:00:00.000000', '2024-04-03T00:00:00.000000', '2024-04-02T00:00:00.000000', 'aa1f6884-b260-4011-a3b8-99aa05fc2258', 'b571706b-a3af-4dde-bb0d-25b5e0295500', 5.0, N'Ngô Vũ Lan Ngọc vượt quá mong đợi của tôi. Sự chuyên nghiệp của Freelancer này thật tuyệt đỉnh.', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'),
('dea935f1-bdf8-4528-b24e-7b1e1b962b06', '0a3ef50a-d6d5-4957-86b4-469ca9089e2f', 1000000, '2024-03-28T00:00:00.000000', '2024-03-28T00:00:00.000000', '2024-03-25T00:00:00.000000', '9378f86c-81c0-4e68-b10e-47f69ffb7580', 'b571706b-a3af-4dde-bb0d-25b5e0295500', 4.5, N'Vũ Ngô Thục Oanh vượt quá mong đợi của tôi. Freelancer thật thân thiện và lịch sự.', 'a7d1f0e8-2a6f-4b9d-aa1c-10f58a1d5d32'); 

INSERT INTO [Services] ([Id], [Note], [AdditionalNote], [ServiceTypeId], [Requirement], [AdditionalRequirement]) VALUES
('edb1a7e1-4096-4e08-9177-9a7c000d27d1', 'Ago play paper office.', 'none', '3b8a2d6a-b0e7-46af-a688-397cea642603', N'[{"Icon":"faHouse","Label":"Loại nhà","Key":"loai_nha","Value":"Căn hộ"},{"Icon":null,"Label":"Số nhà, số phòng, sô lầu, hẻm (ngõ)","Key":"so_nha,_so_phong,_so_lau,_hem_(ngo)","Value":"Chuỗi sử dụng để kiểm thử giá trị"},{"Icon":"faFlag","Label":"Bạn muốn chúng tôi dọn như thế nào?","Key":"ban_muon_chung_toi_don_nhu_the_nao?","Value":"Dọn trọn gói"},{"Icon":"faHouse","Label":"Số lượng phòng","Key":"so_luong_phong","Value":"1"}]', N'[{"Icon":"faDog","Label":"Nhà có thú cưng","Key":"nha_co_thu_cung","Value":false},{"Icon":"faPC","Label":"Nhà có nhiều đồ điện tử","Key":"nha_co_nhieu_do_dien_tu","Value":false},{"Icon":"faBroom","Label":"Nhân viên tự mang theo dụng cụ","Key":"nhan_vien_tu_mang_theo_dung_cu","Value":false}]'),
('0d334250-e671-4cb1-ab9b-8095da15aa0c', 'Positive go Congress mean.', 'none', '3b8a2d6a-b0e7-46af-a688-397cea642603', N'[{"Icon":"faHouse","Label":"Loại nhà","Key":"loai_nha","Value":"Nhà ở, nhà phố"},{"Icon":null,"Label":"Số nhà, số phòng, sô lầu, hẻm (ngõ)","Key":"so_nha,_so_phong,_so_lau,_hem_(ngo)","Value":"Chuỗi sử dụng để kiểm thử giá trị"},{"Icon":"faFlag","Label":"Bạn muốn chúng tôi dọn như thế nào?","Key":"ban_muon_chung_toi_don_nhu_the_nao?","Value":"Dọn theo phòng"},{"Icon":"faHouse","Label":"Số lượng phòng","Key":"so_luong_phong","Value":"5"}]', N'[{"Icon":"faDog","Label":"Nhà có thú cưng","Key":"nha_co_thu_cung","Value":true},{"Icon":"faPC","Label":"Nhà có nhiều đồ điện tử","Key":"nha_co_nhieu_do_dien_tu","Value":true},{"Icon":"faBroom","Label":"Nhân viên tự mang theo dụng cụ","Key":"nhan_vien_tu_mang_theo_dung_cu","Value":true}]'),
('9bd632ed-963b-48da-a641-beb4a9b2701b', 'Program actually race tonight themselves true.', 'none', '3b8a2d6a-b0e7-46af-a688-397cea642603', N'[{"Icon":"faHouse","Label":"Loại nhà","Key":"loai_nha","Value":"Căn hộ"},{"Icon":null,"Label":"Số nhà, số phòng, sô lầu, hẻm (ngõ)","Key":"so_nha,_so_phong,_so_lau,_hem_(ngo)","Value":"Chuỗi sử dụng để kiểm thử giá trị"},{"Icon":"faFlag","Label":"Bạn muốn chúng tôi dọn như thế nào?","Key":"ban_muon_chung_toi_don_nhu_the_nao?","Value":"Dọn trọn gói"},{"Icon":"faHouse","Label":"Số lượng phòng","Key":"so_luong_phong","Value":"3"}]', N'[{"Icon":"faDog","Label":"Nhà có thú cưng","Key":"nha_co_thu_cung","Value":false},{"Icon":"faPC","Label":"Nhà có nhiều đồ điện tử","Key":"nha_co_nhieu_do_dien_tu","Value":true},{"Icon":"faBroom","Label":"Nhân viên tự mang theo dụng cụ","Key":"nhan_vien_tu_mang_theo_dung_cu","Value":true}]'); 

INSERT INTO [OrderService] ([OrderId], [ServiceId]) VALUES
('bfa73a42-b0e0-4b98-a591-9a55f8f906cf', 'edb1a7e1-4096-4e08-9177-9a7c000d27d1'),
('35c893a9-4b47-4a0f-8334-f41dc612579f', '0d334250-e671-4cb1-ab9b-8095da15aa0c'),
('dea935f1-bdf8-4528-b24e-7b1e1b962b06', '9bd632ed-963b-48da-a641-beb4a9b2701b'); 

INSERT INTO [OrderServiceTypes] ([OrderId], [ServiceTypeId]) VALUES
('bfa73a42-b0e0-4b98-a591-9a55f8f906cf', '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('35c893a9-4b47-4a0f-8334-f41dc612579f', '3b8a2d6a-b0e7-46af-a688-397cea642603'),
('dea935f1-bdf8-4528-b24e-7b1e1b962b06', '3b8a2d6a-b0e7-46af-a688-397cea642603'); 

INSERT INTO [OrderSkillsRequired] ([OrderId], [SkillId]) VALUES
('bfa73a42-b0e0-4b98-a591-9a55f8f906cf', '1018f7d5-d4ef-47a1-873d-085588426c72'),
('bfa73a42-b0e0-4b98-a591-9a55f8f906cf', 'cf707aab-5949-4a44-9312-e65ef934f088'),
('35c893a9-4b47-4a0f-8334-f41dc612579f', '92fd24e8-abeb-45d3-a33c-02d24224b78d'),
('35c893a9-4b47-4a0f-8334-f41dc612579f', '562bb844-3fe4-486c-94a6-28876cdb287d'),
('dea935f1-bdf8-4528-b24e-7b1e1b962b06', '4c64db45-bdfe-4931-b9c8-305f30b1cc50'),
('dea935f1-bdf8-4528-b24e-7b1e1b962b06', '1018f7d5-d4ef-47a1-873d-085588426c72'); 

