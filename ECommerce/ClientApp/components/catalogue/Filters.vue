<template>
  <div class="filters mb-4">
    <h5 class="mt-4">Filters</h5>
    <b-btn variant="outline-secondary" @click.prevent="reset">
    <i class="fas fa-sync mr-2"></i> Reset</b-btn>
    <b-list-group class="mt-4">
        <!-- Brand -->
        <filter-accordion>
            <span slot="header">Brand</span>
            <b-row slot="body">
                <b-col cols="6">
                    <div :class="{ 'filter-item': true, 'active': brands.length === 0 }" @click="clearBrands">
                        All
                    </div>
                </b-col>
                <b-col cols="6" v-for="item in filters.brands" :key="item">
                    <div :class="{ 'filter-item': true, 'active': brands.indexOf(item) > -1 }" @click="filterBrand(item)">
                        {{ item }}
                    </div>
                </b-col>
            </b-row>
        </filter-accordion>

        <!-- Price -->
        <filter-accordion>
            <span slot="heade`r">Price</span>
            <div class="slider" slot="body">
                <vue-slider
                    :value="price"
                    formatter="£{value}"
                    :min=0
                    :max=1000
                    :interval=50
                    :lazy=true
                    width="90%"
                    @callback="filterPrice">
                </vue-slider>
            </div>
        </filter-accordion>

        <!-- Screen size -->
        <filter-accordion>
            <span slot="header">Screen size</span>
            <div class="slider" slot="body">
                <vue-slider
                    :value="screenSize"
                    formatter="{value} in"
                    :min=0
                    :max=7
                    :lazy=true
                    width="90%"
                    @callback="filterScreenSize">
                </vue-slider>
            </div>
        </filter-accordion>

        <!-- Color -->
        <filter-accordion>
            <span slot="header">Colour</span>
            <b-row slot="body">
                <b-col cols="6">
                    <div :class="{ 'filter-item': true, 'active': colours.length === 0 }" @click="clearColours">
                        All
                    </div>
                </b-col>
                <b-col cols="6" v-for="item in filters.colours" :key="item">
                    <div :class="{ 'filter-item': true, 'active': colours.indexOf(item) > -1 }" @click="filterColour(item)">
                        {{ item }}
                    </div>
                </b-col>
            </b-row>
        </filter-accordion>

        <!-- OS -->
        <filter-accordion>
            <span slot="header">Operating system</span>
            <b-row slot="body">
                <b-col cols="6">
                    <div :class="{ 'filter-item': true, 'active': os.length === 0 }" @click="clearOS">
                        All
                    </div>
                </b-col>
                <b-col cols="6" v-for="item in filters.os" :key="item">
                    <div :class="{ 'filter-item': true, 'active': os.indexOf(item) > -1 }" @click="filterOS(item)">
                        {{ item }}
                    </div>
                </b-col>
            </b-row>
        </filter-accordion>

        <!-- Features -->
        <filter-accordion>
            <span slot="header">Features</span>
            <b-row slot="body">
                <b-col cols="6">
                    <div :class="{ 'filter-item': true,  'active': features.length === 0 }" @click="clearFeatures">
                        All
                    </div>
                </b-col>
                <b-col cols="6" v-for="item in filters.features" :key="item">
                    <div :class="{ 'filter-item': true, 'active': features.indexOf(item) > -1 }" @click="filterFeature(item)">
                        {{ item }}         
                    </div>
                </b-col>
            </b-row>
        </filter-accordion>
    </b-list-group>
  </div>
</template>

<script>
import FilterAccordion from "./FilterAccordion.vue";
import vueSlider from "vue-slider-component";

export default {
  name: "filters",
  props: {
    filters: {
      type: Object,
      required: true
    }
  },
  components: {
    FilterAccordion,
    vueSlider
  },
  computed: {
    // computed props omitted for brevity...
  },
  methods: {
    // methods omitted for brevity...
  }
};
</script>

<style>

</style>
