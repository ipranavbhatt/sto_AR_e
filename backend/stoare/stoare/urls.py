"""stoare URL Configuration

The `urlpatterns` list routes URLs to views. For more information please see:
    https://docs.djangoproject.com/en/3.2/topics/http/urls/
Examples:
Function views
    1. Add an import:  from my_app import views
    2. Add a URL to urlpatterns:  path('', views.home, name='home')
Class-based views
    1. Add an import:  from other_app.views import Home
    2. Add a URL to urlpatterns:  path('', Home.as_view(), name='home')
Including another URLconf
    1. Import the include() function: from django.urls import include, path
    2. Add a URL to urlpatterns:  path('blog/', include('blog.urls'))
"""
from django.contrib import admin
from django.urls import path
from django.conf.urls import include, url
from django.conf import settings
from django.conf.urls.static import static
from django_email_verification import urls as email_urls
from rest_framework_swagger.views import get_swagger_view

schema_view = get_swagger_view(title='stoARe API')

urlpatterns = [
    path('admin/', admin.site.urls),
    path("shops/", include("shop.urls")),
    path("products/", include("product.urls")),
    path("utils/", include("utils.urls")),
    path("auth/", include("user_auth.urls")),
    path("order/", include("orders.urls")),
    path('email/', include(email_urls)),
    url(r'^$', schema_view),
]

# serve images
urlpatterns += static(settings.MEDIA_URL, document_root=settings.MEDIA_ROOT)
