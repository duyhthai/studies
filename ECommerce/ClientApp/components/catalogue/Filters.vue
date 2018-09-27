<template>
  <div class="filters mb-4">
    <h5 class="mt-4">Filters</h5>
    <b-btn variant="outline-secondary" @click.prevent="reset">
    <i class="fas fa-sync mr-2"></i> Reset</b-btn>
    <b-list-group class="mt-4">
        <!-- Brand -->
        <filter-accordion>
            <span slot="header">Brand</span>
            <multi-select-filter slot="body" query-key="brands" :items="filters.brands" />
        </filter-accordion>

        <!-- Price -->
        <filter-accordion>
            <span slot="header">Price</span>
            <range-filter slot="body"
                :min=0
                :max=1000
                :interval=50
                formatter="£{value}"
                min-query-key="minPrice"
                max-query-key="maxPrice" />
        </filter-accordion>

        <!-- Screen size -->
        <filter-accordion>
            <span slot="header">Screen size</span>
            <range-filter slot="body"
                :min=0
                :max=7
                formatter="{value} in"
                min-query-key="minScreen"
                max-query-key="maxScreen" />
        </filter-accordion>

        <!-- Capacity -->
        <filter-accordion>
            <span slot="header">Capacity</span>
            <multi-select-filter slot="body" query-key="capacity" :items="filters.storage" />
        </filter-accordion>

        <!-- Color -->
        <filter-accordion>
            <span slot="header">Colour</span>
            <multi-select-filter slot="body" query-key="colours" :items="filters.colours" />
        </filter-accordion>

        <!-- OS -->
        <filter-accordion>
            <span slot="header">Operating system</span>
            <multi-select-filter slot="body" query-key="os" :items="filters.os" />
        </filter-accordion>

        <!-- Features -->
        <filter-accordion>
            <span slot="header">Features</span>
            <multi-select-filter slot="body" query-key="features" :items="filters.features" />
        </filter-accordion>
    </b-list-group>
  </div>
</template>


<script>
import FilterAccordion from "./FilterAccordion.vue";
import MultiSelectFilter from "./MultiSelectFilter.vue";
import RangeFilter from "./RangeFilter.vue";

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
    MultiSelectFilter,
    RangeFilter
  },
  methods: {
    reset() {
      this.$router.push({ query: {} });
    }
  }
};
</script>


<style lang="scss" scoped>
.filter-item {
  margin: 10px 0;
  border: 1px solid #ccc;
  border-radius: 5px;
  padding: 10px;
  text-align: center;
  cursor: pointer;

  &.active {
    font-weight: bold;
    color: #17a2b8;
    border-color: #17a2b8;
  }
}

.slider {
  padding: 35px 0 10px 10px;
}
</style>
