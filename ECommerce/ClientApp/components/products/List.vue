<template>
  <div class="products">
    <h1>Products</h1>
    <div class="list">
      <div class="item" v-for="product in products" :key="product.slug">
        <h3 @click="select(product)">
            {{ product.name }}
        </h3>
        <img :src="product.thumbnail" :alt="product.name" @click="select(product)" />
        <p @click="select(product)">
            {{ product.shortDescription }} 
        </p>
        <p @click="select(product)">
            {{ product.price }}
        </p>
        <hr />
      </div>
    </div>

    <product-details class="details" v-if="selectedProduct" :product="selectedProduct" />
  </div>
</template>


<script>
import ProductDetails from '.Details.vue';

export default {
    name: "product-list",
    data() {
        return {
            products: [
                //products omitted for brevity
                {
                    name: "Samsung Galaxy S8",
                    slug: "samsung-galaxy-s8",
                    thumbnail: "http://placehold.it/200x300",
                    shortDescription: "Samsung Galaxy S8 Android smartphone with true edge to edge display",
                    price: 499.99,
                    description: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tempora ad cum laudantium, omnis fugit amet iure animi corporis labore repellat magnam perspiciatis explicabo maiores fuga provident a obcaecati tenetur nostrum, quidem quod dignissimos, voluptatem quasi? Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."
                },
                {
                    name: "Sony XZs",
                    slug: "sony-xzs",
                    thumbnail: "http://placehold.it/200x300",
                    shortDescription: "Lorem ipsum dolor sit amet consectetur adipisicing elit. Perferendis tem",
                    price: 399.99,
                    description: "Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."
                },
                {
                    name: "Apple iPhone X",
                    slug: "apple-iphone-x",
                    thumbnail: "http://placehold.it/200x300",
                    shortDescription: "Apple iPhone X smartphone with super retina display.",
                    price: 499.99,
                    description: "Nisi quaerat, fugit voluptas ducimus facilis impedit quod dicta, laborum sint iure nihil veniam aspernatur delectus officia culpa, at cupiditate? Totam minima ut deleniti laboriosam dolores cumque in, nesciunt optio! Quod recusandae voluptate facere pariatur soluta vel corrupti tenetur aut maiores, cumque mollitia fugiat laudantium error odit voluptas nobis laboriosam quo, rem deleniti? Iste quidem amet perferendis sed iusto tempora modi illo tempore quibusdam laborum? Dicta aliquam libero, facere, maxime corporis qui officiis explicabo aspernatur non consequatur mollitia iure magnam odit enim. Eligendi suscipit, optio officiis repellat eos quis iure? Omnis, error aliquid quibusdam iste amet nihil nisi cumque magni sequi enim illo autem nesciunt optio accusantium animi commodi tenetur neque eum vitae est."
                },
            ],
            selectedProduct: null
        };
    },
    methods: {
        select(product) {
            this.selectedProduct = product;
        }
    }
};
</script>


<style>
    * {
        box-sizing: border-box !important;
    }

    .products {
        padding: 20px;
        max-width: 1200px;
        margin: 0 auto;
    }

    .list,
    .details {
        width: 50%;
        float: left;
    }

    .list .item {
        width: 50%;
        float: left;
        padding: 20px 10px 20px 0;
    }

    .list img,
    .list h3,
    .list p {
        cursor: pointer;
    }

    .list img {
        width: 100px;
    }
</style>